using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;

namespace Vagga.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        BaseOutput CreateUser(UserModelInput input);
    }
}
