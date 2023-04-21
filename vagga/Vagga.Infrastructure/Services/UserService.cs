using Vagga.Domain.Interfaces.Repositories;
using Vagga.Domain.Interfaces.Services;
using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;

namespace Vagga.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseOutput CreateUser(UserInput input)
        {

            var spacePosition = input.FullName.IndexOf(' ');

            if (spacePosition == -1)
            {
                var resultError = new BaseOutput();
                resultError.Error = true;
                resultError.Message = "Ultimo nome invalido";
                return resultError;
            }

            var _firstName = input.FullName[..spacePosition];
            var _lastName = input.FullName[(spacePosition + 1)..];



            var model = new UserModelInput() { 
                FirstName= _firstName,
                LastName= _lastName,
                Phone = input.Phone,
                Email= input.Email, 
                Password= input.Password
            };

            var result = _userRepository.CreateUser(model);

            return result;
        }
    }
}
