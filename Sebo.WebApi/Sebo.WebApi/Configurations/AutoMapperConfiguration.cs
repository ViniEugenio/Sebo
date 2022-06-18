using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sebo.Application.Commands.CreateChapter;
using Sebo.Application.Commands.CreateManga;
using Sebo.Application.Commands.CreateUser;
using Sebo.Application.ViewModels.UserViewModels;
using Sebo.Core.Entities;

namespace Sebo.WebApi.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AutoMapperConfigure(this IServiceCollection services)
        {

            var config = new MapperConfiguration(cfg =>
            {

                #region User Maps

                cfg.CreateMap<CreateUserCommand, User>();
                cfg.CreateMap<User, UserDetailViewModel>();

                #endregion
                #region Chapter Maps

                cfg.CreateMap<CreateMangaCommand, Manga>();

                #endregion
                #region Chapter Maps

                cfg.CreateMap<CreateChapterCommand, Chapter>();

                #endregion

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
