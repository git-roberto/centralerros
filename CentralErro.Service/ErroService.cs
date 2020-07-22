using CentralErro.Model;
using CentralErro.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralErro.Service
{
    public class ErroService : ServiceBase<Erro>
    {
        public List<ErroDTO> ListarDTO()
        {
            IQueryable<Erro> lst = base.Listar();

            List<ErroDTO> lstRetorno = lst.Select(x => new ErroDTO
            {
                Id = x.Id,
                Descricao = x.Descricao,
                DataErro = x.DataErro,
                TipoErro = x.TipoErro.ToDTO<TipoErro, TipoErroDTO>()
            }).ToList();

            return lstRetorno;
        }
    }
}
