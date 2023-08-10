using api_psm.domain.Entidades;
using api_psm.domain.Interface.Repository;
using api_psm.infra.Interface;
using Dapper;
using System.Data.SqlClient;

namespace api_psm.infra.data.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UsuarioRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        private SqlConnection GetSqlConnection()
        {
            return (SqlConnection)_dbConnectionFactory.CreateSqlConnection("MySql");
        }

        public  Task<Usuario> Authenticate(string username, string password)
        {
            using (var con = (SqlConnection)_dbConnectionFactory.CreateMySqlConnection("Connection"))
            {
                con.Open();

                string sql = @"SELECT * FROM users WHERE username = username and password = @password";

               var usuario = con.Query<Usuario>(sql, new { username = username, password = password } );
            }
            return Task.FromResult(new Usuario());  

        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

      

    }
}
