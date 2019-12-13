using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using Senai.OpFilx.WebApi.sln.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
