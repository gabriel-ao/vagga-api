using System.Data;

namespace Vagga.Domain.Interfaces.Repositories
{
    public interface IDapperConnectionFactory
    {
        IDbConnection GetConnection { get; }
        void CloseConnection();
    }
}
