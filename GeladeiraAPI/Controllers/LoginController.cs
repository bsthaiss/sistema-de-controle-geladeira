using Microsoft.AspNetCore.Mvc;
using Services;
using EstruturaGeladeira;
using System;
using Repository.Context;
using Xamarin.Forms.Internals;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null)
                return BadRequest("Os dados de login não podem ser nulos.");

            try
            {
                var token = _loginService.GerarToken(login);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível realizar o login: {ex.Message}");
            }
        }

        [HttpPost("usuario")]
        public IActionResult Register([FromBody] Registrar novoUsuario)
        {
            if (novoUsuario == null)
                return BadRequest("Os dados do usuário não podem ser nulos.");

            try
            {
                var usuario = _loginService.Registrar(novoUsuario);

                if (usuario != null)
                    return CreatedAtAction(nameof(Login), new { id = usuario.Id }, usuario);

                return BadRequest("Não foi possível inserir o usuário!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível inserir o usuário: {ex.Message}");
            }
        }
    }
}