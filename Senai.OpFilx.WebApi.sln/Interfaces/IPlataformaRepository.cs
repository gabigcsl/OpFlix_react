using Senai.OpFilx.WebApi.sln.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Interfaces
{
    interface IPlataformaRepository
    {

        void Atualizar(Plataformas plataformas);

        Plataformas BuscarPorId(int id);

        void Cadastrar(Plataformas plataformas);

        List<Plataformas> Listar();

    }
}
