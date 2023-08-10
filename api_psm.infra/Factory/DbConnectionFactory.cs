using api_psm.infra.data.Enum;
using api_psm.infra.data.Helpers;
using api_psm.infra.Interface;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;
using System.Data.Common;

namespace api_psm.infra.data.Factory
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
       // private readonly IDictionary<string, string> _connectionDictionary;
        private readonly IConfiguration _configuration;


        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnectionFactory()
        {
                
        }

        private string GetConnectionString(string connectionName)
        {
            //_connectionDictionary.TryGetValue(connectionName, out string connectionString);

            var connectionString = _configuration.GetConnectionString(connectionName);

            if (connectionString == null)
            {
                throw new Exception(string.Format("Connection string {0} was not found", connectionName));
            }

            return connectionString;
        }

        public IDbConnection CreateSqlConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.SqlServer);
        }

        public IDbConnection CreateSqLiteConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.SqLite);
        }

        public IDbConnection CreateMySqlConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.MySql);
        }

        public IDbConnection CreatePostgreSqlConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.PostgreSql);
        }

#if NETFULL
        public IDbConnection CreateOleDbConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.OleDb);
        }

        public IDbConnection CreateSqlServerCompactConnection(string connectionName)
        {
            return CreateDbConnection(GetConnectionString(connectionName), DataAccessProviderTypes.SqlServerCompact);
        }
#endif

        private IDbConnection CreateDbConnection(string connectionString, DataAccessProviderTypes providerType)
        {
            //// Assume failure.
            //DbConnection connection = null;

            //// Create the DbProviderFactory and DbConnection.
            //if (connectionString != null)
            //{
            //    DbProviderFactory factory = DbProviderFactoryUtils.GetDbProviderFactory(providerType);

            //    connection = factory.CreateConnection();
            //    connection.ConnectionString = connectionString;
            //}
            //// Return the connection.
            ///4
            ///

            var connection = new MySqlConnection(connectionString);


            return connection;
        }
    }
}
