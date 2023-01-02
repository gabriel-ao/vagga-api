using Dapper;
using Vagga.Domain.Interfaces.Repositories;
using Vagga.Domain.Models.Database;
using Vagga.Domain.Models.Output;

namespace Vagga.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDapperConnectionFactory _connection;

        public AuthRepository(IDapperConnectionFactory connectionFactory)
        {
            _connection = connectionFactory;
        }

        public AuthOutput Auth(string email, string password)
        {
            try
            {
                var QUERY = $"SELECT * FROM \"public\".\"auth\"('{email}','{password}')"; ;

                var connection = _connection.GetConnection;
                var result = connection.QueryFirstOrDefault<AuthModel>(QUERY);



                AuthOutput response = new AuthOutput();

                response.Token = result.firstname;

                return response;

            }
            catch (Exception ex) { 

                AuthOutput returnError = new AuthOutput();

                returnError.Token = "";

                return returnError;
            }


        }
    }
}
