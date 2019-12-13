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

    public class LocalizacaoController : ControllerBase
    {
        public ILocalizacaoRepository LocalizacaoRepository { get; set; }

        public LocalizacaoController()
        {
            LocalizacaoRepository = new LocalizacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(LocalizacaoRepository.Listar());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacoes localizacoes)
        {
            try
            {
                LocalizacaoRepository.Cadastrar(localizacoes);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

