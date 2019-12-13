using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamentos Lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext()) 
            {
                Lancamentos LancamentosBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == Lancamentos.IdLancamento);
                LancamentosBuscado.Nome = Lancamentos.Nome;
                ctx.Lancamentos.Update(LancamentosBuscado);
                ctx.SaveChanges();
            }
        }

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }

        public void Cadastrar(Lancamentos lancamentos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamentos);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos Lancamentos = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(Lancamentos);
                ctx.SaveChanges();
            }
        }

        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }
    }
}
