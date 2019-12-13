using Microsoft.EntityFrameworkCore;
using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.Interfaces;
using Senai.OpFilx.WebApi.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
               return ctx.Usuarios.Include(x => x.IdPermissaoNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                //if (usuario == null)
                //    return null;
                //return usuario;
            }
        }
    }
}
