using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;

namespace Vagga.Domain.Interfaces.Services
{
    public interface IUserService
    {
        BaseOutput CreateUser(UserInput input);
    }
}
