using Vagga.Domain.Models.Output;

namespace Vagga.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        AuthOutput Auth (string username, string password);

    }
}
