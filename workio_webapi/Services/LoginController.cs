using System;
using System.Collections.Generic;
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

            var usertemp = db.Usuario.Where(u => u.Username == login.Username && u.Contrasenia == login.Contrasenia);
            if(usertemp.Count() > 0)
            {
                user = usertemp.FirstOrDefault() as Usuario;
            }

            return user;
        }

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