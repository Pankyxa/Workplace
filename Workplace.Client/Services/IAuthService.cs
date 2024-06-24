using System.Threading.Tasks;

namespace Workplace.Client.Services
{
    public interface IAuthService
    {
        Task<string> GetTokenAsync(string username, string password);
        Task<bool> IsAuthenticatedAsync();
    }
}