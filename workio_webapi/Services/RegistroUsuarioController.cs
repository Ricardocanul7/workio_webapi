using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using workio_webapi.Models;

namespace workio_webapi.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroUsuarioController : ControllerBase
    {
        private readonly dbworkioContext _context;

        public RegistroUsuarioController(dbworkioContext context)
        {
            _context = context;
        }

        [HttpPost("usuario/[action]")]
        public async Task<ActionResult<Usuario>> RegistroUsuario(Usuario usuario)
        {
            string contraseniaDecrypted = usuario.Contrasenia;

            usuario.Contrasenia = Security.EncryptPasswords.HashPassword(contraseniaDecrypted);

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", "Usuarios", new { id = usuario.Id }, usuario);
        }

        [HttpGet("[action]")]
        public bool UsernameExist(string username)
        {
            return _context.Usuario.Any(e => e.Username == username);
        }
    }
}