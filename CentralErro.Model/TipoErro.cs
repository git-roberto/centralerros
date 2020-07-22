using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CentralErro.Model
{
    public class TipoErro
    {
        public TipoErro()
        {
            Erro = new HashSet<Erro>();
        }

        public int? Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        public ICollection<Erro> Erro { get; set; }
    }
}
