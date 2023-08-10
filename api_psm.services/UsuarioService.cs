using api_psm.domain.Entidades;
using api_psm.domain.Interface.Services;

namespace api_psm.Services
{
    public class UsuarioService : IUsuarioService
    {
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