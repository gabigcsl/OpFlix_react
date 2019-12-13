using System;
using System.Collections.Generic;

namespace Senai.OpFilx.WebApi.sln.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public string Tipo { get; set; }
        public string Duracao { get; set; }
        public DateTime? Datal { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdPlataforma { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
    }
}
