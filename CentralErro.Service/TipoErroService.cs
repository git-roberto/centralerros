using CentralErro.Model;
using CentralErro.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralErro.Service
{
    public class TipoErroService : ServiceBase<TipoErro>
    {
        public List<TipoErroDTO> ListarDTO()
        {
            IQueryable<TipoErro> lst = base.Listar();

            List<TipoErroDTO> lstRetorno = lst.Select(x => new TipoErroDTO
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nome = x.Nome
            }).ToList();

            return lstRetorno;
        }
    }
}
