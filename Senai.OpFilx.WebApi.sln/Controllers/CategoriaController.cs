using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using Senai.OpFilx.WebApi.sln.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {

                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }

        [HttpPut]
        public IActionResult Atualizar (Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId(categoria.IdCategoria);
                if (CategoriaBuscada == null)
                    return NotFound();
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "erro" });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        
    }
}
