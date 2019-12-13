using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using Senai.OpFilx.WebApi.sln.Repositories;
using Senai.OpFilx.WebApi.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository LoginRepository { get; set; }

        public LoginController()
        {
            LoginRepository = new LoginRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = LoginRepository.BuscarPorEmailESenha(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Erro" });

                var claims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuarios.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdPermissao.ToString())

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        
    }
}
