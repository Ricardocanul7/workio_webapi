using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using workio_webapi.Models;
using workio_webapi.Security;

namespace workio_webapi.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Login(string username, string pass)
        {
            Usuario login = new Usuario();
            login.Username = username;
            login.Contrasenia = pass;

            //IActionResult response = Unauthorized();

            Usuario user = AuthenticateUser(login);

            //if(user != null)
            //{
            //    var tokenStr = GenerateJSONWebToken(user);
            //    response = Ok(new { token = tokenStr });
            //}

            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        private string GenerateJSONWebToken(Usuario userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new Claim[] { 
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        private Usuario AuthenticateUser(Usuario login)
        {
            Usuario user = null;
            dbworkioContext db = new dbworkioContext();

            login.Contrasenia = EncryptPasswords.HashPassword(login.Contrasenia);

            var usertemp = db.Usuario.Where(u => u.Username == login.Username && u.Contrasenia == login.Contrasenia);
            if(usertemp.Count() > 0)
            {
                user = usertemp.FirstOrDefault() as Usuario;
            }

            return user;
        }

        /** Se crea metodo para encriptar todas las contraseñas para que se pueda usar los metodos que ya hacen login y registro con la contraseña encryptada (SOLO USAR UNA VEZ, HA SIDO COMENTADO PORQUE YA HA SIDO USADO) */
        /*
        [HttpGet("[Action]")]
        public async Task<IActionResult> EncryptPasswordAll()
        {
            List<Usuario> listUsers;
            using (var db = new dbworkioContext())
            {
                listUsers = db.Usuario.ToList();
            }

            using (var db = new dbworkioContext())
            {
                for (int i = 0; i < listUsers.Count; i++)
                {
                    listUsers[i].Contrasenia = EncryptPasswords.HashPassword(listUsers[i].Contrasenia);

                    db.Entry(listUsers[i]).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                try
                {
                    await db.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
                    return NotFound();
                }
            }
        }
        */

        //[Authorize]
        //[HttpPost("Post")]
        //public string Post()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    IList<Claim> claim = identity.Claims.ToList();
        //    var userName = claim[0].Value;
        //    return "Welcome to: " + userName;
        //}
    }
}