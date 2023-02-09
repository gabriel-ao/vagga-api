using Vagga.Domain.Models.Output;

namespace Vagga.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        AuthOutput Auth(string email, string password);

    }
}
