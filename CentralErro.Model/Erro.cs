using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CentralErro.Model
{
    public class Erro
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataErro { get; set; }

        [ForeignKey("IdTipoErro")]
        public TipoErro TipoErro { get; set; }
    }
}
