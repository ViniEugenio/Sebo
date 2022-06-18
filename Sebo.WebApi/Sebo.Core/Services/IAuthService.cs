namespace Sebo.Core.Services
{
    public interface IAuthService
    {
        string GenerateJWTToken(string Email, string Role);
    }
}
