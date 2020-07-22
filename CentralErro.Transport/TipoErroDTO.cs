using CentralErro.Core;
using CentralErro.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Transport
{
    public class TipoErroDTO : BaseDTO<TipoErro, TipoErroDTO>
    {
        public TipoErroDTO()
        {

        }

        public TipoErroDTO(TipoErro model) 
            : base(model)
        {
            Id = model.Id;
            Codigo = model.Codigo;
            Nome = model.Nome;
        }


        public override TipoErro Modelo(Contexto conn)
        {
            TipoErro model = null;
            if (Id.HasValue)
            {
                model = conn.TipoErro.Find(Id.Value);
            }
            else
            {
                model = new TipoErro();
            }

            model.Codigo = Codigo;
            model.Nome = Nome;

            return model;
        }

        public int? Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}
