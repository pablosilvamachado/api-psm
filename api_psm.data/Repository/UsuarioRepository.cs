using api_psm.domain.Entidades;
using api_psm.domain.Interface.Repository;
using api_psm.infra.Interface;
using Dapper;
using System.Data;

namespace api_psm.data.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {

        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UsuarioRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }      

        public async Task<Usuario> Authenticate(string username, string password)
        {
            IEnumerable<Usuario> usuario;
            try
            {               
                using (IDbConnection con = _dbConnectionFactory.CreateMySqlConnection("DefaultConnection"))
                {
                    con.Open();

                    string sql = @"SELECT  user_login as Login, user_pass as Senha 
                                   FROM users 
                                   WHERE user_login = @username and user_pass = @password";

                    usuario = await con.QueryAsync<Usuario>(sql, new { username = username, password = password });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult<Usuario>(usuario.FirstOrDefault<Usuario>()).Result;
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
