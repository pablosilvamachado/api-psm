using api_psm.domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_psm.domain.Interface.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> Authenticate(string username, string password);
        Task<IEnumerable<Usuario>> GetAll();
    }
}
