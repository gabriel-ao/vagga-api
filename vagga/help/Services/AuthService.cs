using Vagga.Domain.Interfaces.Repositories;
using Vagga.Domain.Interfaces.Services;
using Vagga.Domain.Models.Output;

namespace Vagga.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public AuthOutput Auth(string username, string password)
        {
            var result = _repository.Auth(username, password);

            return result;
        }
    }
}
