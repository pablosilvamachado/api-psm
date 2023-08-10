using api_psm.domain.Entidades;
using api_psm.domain.Interface.Repository;
using api_psm.infra.data.Factory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace api_psm.infra.data.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private DbConnectionFactory _dbConnectionFactory;

        public UsuarioRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        private SqlConnection GetSqlConnection()
        {
            return (SqlConnection)_dbConnectionFactory.CreateSqlConnection("MySql");
        }

        public Task<Usuario> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

      

    }
}
