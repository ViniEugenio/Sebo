using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sebo.ImageService.Models;
using Sebo.ImageService.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sebo.ImageService.Services
{

    public interface IImageService
    {
        Task<bool> UploadImage(ChapterFilesIntegrationEvent ChapterFiles);
    }

    public class ImageService : IImageService
    {

        private readonly HttpClient Client;
        private readonly IConfiguration Configuration;
        private readonly IFileRepository FileRepository;

        public ImageService(IConfiguration Configuration, IFileRepository FileRepository)
        {

            this.Configuration = Configuration;
            this.FileRepository = FileRepository;
            Client = new HttpClient();
            Client.BaseAddress = new Uri(this.Configuration.GetSection("ImageBBApi:EndPoint").Value);

        }

        public async Task<bool> UploadImage(ChapterFilesIntegrationEvent ChapterFiles)
        {

            Dictionary<string, int> FilesAuxiliar = new Dictionary<string, int>();
            foreach (var ChapterFile in ChapterFiles.Files)
            {

                var Content = new MultipartFormDataContent();
                Content.Add(new StringContent(Convert.ToBase64String(ChapterFile.File)), "image");
                Content.Add(new StringContent($"{Guid.NewGuid()}"), "name");

                HttpResponseMessage response = await Client.PostAsync($"upload?key={Configuration.GetSection("ImageBBApi:Key").Value}", Content);
                if (response.IsSuccessStatusCode)
                {

                    var FormatedResponse = JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
                    FilesAuxiliar.Add(FormatedResponse.data.url, ChapterFile.Order);

                }

                else
                {
                    return false;
                }

            }

            await FileRepository.AddChapterFiles(FilesAuxiliar.Select(file => new Persistence.Entities.File()
            {
                ChapterId = ChapterFiles.ChapterId,
                DataCadastro = DateTime.Now,
                Url = file.Key,
                Order = file.Value,
                IsDeleted = false
            }).ToList());

            return true;

        }

    }
}
