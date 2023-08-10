using api_psm.domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_psm.domain.Interface.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Authenticate(string username, string password);
        Task<IEnumerable<Usuario>> GetAll();
    }
}
