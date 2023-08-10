using api_psm.domain.Entidades;
using api_psm.domain.Interface.Repository;
using api_psm.domain.Interface.Services;

namespace api_psm.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Authenticate(string username, string password)
        {
            return await _usuarioRepository.Authenticate(username, password);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }
    }
}