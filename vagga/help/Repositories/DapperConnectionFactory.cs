using Npgsql;
using System.Data;
using Vagga.Domain.Interfaces.Repositories;

namespace Vagga.Infrastructure.Repositories
{
    public class DapperConnectionFactory : IDapperConnectionFactory
    {
        private IDbConnection _connection;

        public DapperConnectionFactory()
        {

        }

        public IDbConnection GetConnection
        {
            get
            {
                try
                {
                    _connection = new NpgsqlConnection("Server=localhost;Database=Vagga-DB;Port=5432;User Id=postgres;Password=gabriel;");
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                }
                catch (Exception ex) { }

                return _connection;
            }

        }

        public void CloseConnection()
        {
            if(_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
