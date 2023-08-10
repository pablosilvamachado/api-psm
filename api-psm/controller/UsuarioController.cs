using api_psm.domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using api_psm.Models;
using api_psm.Controller;

namespace api_psm.controller
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _UsuarioService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _UsuarioService.GetAll();
            return Ok(users);
        }
    }
}

