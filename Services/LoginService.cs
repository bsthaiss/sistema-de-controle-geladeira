using EstruturaGeladeira;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Context;
using Services.Context;
using System;
using System.Linq;

namespace Services
{
    public class LoginService
    {
        private readonly string _key;
        private readonly GeladeiraDbContext _context;
        private readonly IConfiguration _config;

        public LoginService(IConfiguration config, GeladeiraDbContext context)
        {
            _key = "AtivadoModoT3Ste";
        }

        public string GerarToken(Login resource)
        {
            // Acessar a tabela de usuários através do contexto
            var usuario = _context.Usuarios.FirstOrDefault(x => x.UserName == resource.Nome);

            if (usuario == null)
                throw new Exception("Username e senha não conferem.");

            var passwordHash = SenhaHash.ComputeHash(resource.Senha, usuario.SenhaSalt, _config["Hash:pepper"], 3);

            if (usuario.SenhaHash != passwordHash)
                throw new Exception("Username e senha não conferem.");

            return GenerateJwtToken(usuario.Nome);
        }
    }
}
