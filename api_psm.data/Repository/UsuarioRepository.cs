using api_psm.domain.Entidades;
using api_psm.domain.Interface.Repository;
using api_psm.infra.Interface;
using Dapper;
using MySqlConnector;


namespace api_psm.data.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UsuarioRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }      

        public Task<Usuario> Authenticate(string username, string password)
        {
            IEnumerable<Usuario> usuario;
            try
            {               
                using (var con = (MySqlConnection)_dbConnectionFactory.CreateMySqlConnection("DefaultConnection"))
                {
                    con.Open();

                    string sql = @"SELECT  user_login as Login, user_pass as Senha FROM users WHERE user_login = @username and user_pass = @password";

                    usuario = con.Query<Usuario>(sql, new { username = username, password = password });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(usuario.FirstOrDefault());
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

      

    }
}
