namespace Sebo.Application.ViewModels.UserViewModels
{
    public class LoginUserViewModel
    {

        public string Message { get; set; }
        public string Token { get; set; }

        public LoginUserViewModel(string Message, string Token)
        {
            this.Message = Message;
            this.Token = Token;
        }

    }
}
