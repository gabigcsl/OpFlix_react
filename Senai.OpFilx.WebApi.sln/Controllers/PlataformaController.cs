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
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformaController()
        {
            PlataformaRepository = new PlataformaRepository();
        }


        [HttpPut]
        public IActionResult Atualizar(Plataformas plataformas)
        {
            try
            {
                Plataformas PlataformaBuscada = PlataformaRepository.BuscarPorId(plataformas.IdPlataforma);
                if (PlataformaBuscada == null)
                    return NotFound();
                PlataformaRepository.Atualizar(plataformas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "erro" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataformas plataformas = PlataformaRepository.BuscarPorId(id);
            if (plataformas == null)
                return NotFound();
            return Ok(plataformas);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataformas)
        {
            try
            {
                PlataformaRepository.Cadastrar(plataformas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
