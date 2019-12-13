using Senai.OpFilx.WebApi.sln.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Interfaces
{
   public interface ILocalizacaoRepository
    {
        void Cadastrar(Localizacoes localizacoes);

        List<Localizacoes> Listar();
    }
}
