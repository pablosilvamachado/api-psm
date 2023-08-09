using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_psm.infra.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateSqlConnection(string connectionName);

        IDbConnection CreateSqLiteConnection(string connectionName);

        IDbConnection CreateMySqlConnection(string connectionName);

        IDbConnection CreatePostgreSqlConnection(string connectionName);

#if NETFULL
        IDbConnection CreateOleDbConnection(string connectionName);

        IDbConnection CreateSqlServerCompactConnection(string connectionName);
#endif
    }
}
