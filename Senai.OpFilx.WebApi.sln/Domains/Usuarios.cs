using System;
using System.Collections.Generic;

namespace Senai.OpFilx.WebApi.sln.Domains
{
    public partial class Usuarios
    {
        public int IdUsuarios { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdPermissao { get; set; }

        public Permissoes IdPermissaoNavigation { get; set; }
    }
}
