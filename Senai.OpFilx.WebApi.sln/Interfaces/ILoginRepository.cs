using Senai.OpFilx.WebApi.sln.Domains;
using Senai.OpFilx.WebApi.sln.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFilx.WebApi.sln.Interfaces
{
    interface ILoginRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

    }
}
