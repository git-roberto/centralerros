using CentralErro.Core;
using CentralErro.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Transport
{
    public class ErroDTO : BaseDTO<Erro, ErroDTO>
    {
        public ErroDTO()
        {

        }

        public ErroDTO(Erro model)
            : base(model)
        {
            Id = model.Id;
            Descricao = model.Descricao;
            DataErro = model.DataErro;

            TipoErro = model.TipoErro.ToDTO<TipoErro, TipoErroDTO>();
        }


        public override Erro Modelo(Contexto conn)
        {
            Erro model = null;
            if (Id.HasValue)
            {
                model = conn.Erro.Find(Id.Value);
            }
            else
            {
                model = new Erro();
            }

            model.Id = Id;
            model.Descricao = Descricao;
            model.DataErro = DataErro;

            model.TipoErro = TipoErro != null && TipoErro.Id.HasValue ? conn.TipoErro.Find(TipoErro.Id.Value) : null;

            return model;
        }

        public int? Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataErro { get; set; }


        public TipoErroDTO TipoErro { get; set; }
    }
}
