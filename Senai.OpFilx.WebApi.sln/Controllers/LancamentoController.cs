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
    public class LancamentoController : ControllerBase
    {

        private ILancamentoRepository LancamentoRepository { get; set; }

        public LancamentoController()
        {
            LancamentoRepository = new LancamentoRepository();
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                LancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Lancamentos LancamentoDeletar = LancamentoRepository.BuscarPorId(id);
                if (LancamentoDeletar == null)
                    return NotFound();
                LancamentoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "erro" });
            }
        }
        


        [HttpPut]
        public IActionResult Atualizar(Lancamentos lancamentos)
        {
            try
            {
                Lancamentos LancamentosBuscados = LancamentoRepository.BuscarPorId(lancamentos.IdLancamento);
                if (LancamentosBuscados == null)
                    return NotFound();
                LancamentoRepository.Atualizar(lancamentos);
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
            Lancamentos lancamentos = LancamentoRepository.BuscarPorId(id);
            if (lancamentos == null)
                return NotFound();
            return Ok(lancamentos);
        }
    }
}
