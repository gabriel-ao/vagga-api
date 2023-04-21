using Dapper;
using Vagga.Domain.Interfaces.Repositories;
using Vagga.Domain.Models.Base;
using Vagga.Domain.Models.Input;

namespace Vagga.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperConnectionFactory _connection;

        public UserRepository(IDapperConnectionFactory connection)
        {
            _connection = connection;
        }

        public BaseOutput CreateUser(UserModelInput input)
        {
            var response = new BaseOutput();

            var QUERY = $"SELECT * FROM \"public\".\"Create_User\"(" +
                $"'{input.FirstName}', " +
                $"'{input.LastName}', " +
                $"'{input.Phone}', " +
                $"'{input.Email}', " +
                $"'{input.Password}')";

            try
            {
                var connection = _connection.GetConnection;
                response = connection.QueryFirstOrDefault<BaseOutput>(QUERY);


                return response;
            }
            catch (Exception ex)
            {
                // TODO CRIAR LOG PARA ERRO NA BASE
                response.Error = true;
                response.Message = ex.Message;
                return response;
            }
            finally
            {
                _connection.CloseConnection();
            }

        }
    }
}
