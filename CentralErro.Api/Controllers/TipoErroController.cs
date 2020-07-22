using CentralErro.Model;
using CentralErro.Service;
using CentralErro.Transport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CentralErro.Api.Controllers
{
    public class TipoErroController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            using (TipoErroService service = new TipoErroService())
            {
                List<TipoErroDTO> lstRetorno = service.ListarDTO();

                return Json(new { resultado = lstRetorno, qtdRegistro = lstRetorno.Count() });
            }
        }

        [HttpPost]
        public ActionResult Buscar(int id)
        {
            using (TipoErroService service = new TipoErroService())
            {
                TipoErroDTO retorno = service.Buscar(id).ToDTO<TipoErro, TipoErroDTO>();

                return Json(new { resultado = retorno });
            }
        }

        [HttpPost]
        public ActionResult Incluir([FromBody]TipoErroDTO registro)
        {
            using (TipoErroService service = new TipoErroService())
            {
                var model = registro.ToModel<TipoErro, TipoErroDTO>(service.Conn);

                service.Incluir(model);

                return Json(new { mensagem = "O registro foi incluído com sucesso" });
            }
        }

        [HttpPost]
        public ActionResult Atualizar(TipoErroDTO registro)
        {
            using (TipoErroService service = new TipoErroService())
            {
                var model = registro.ToModel<TipoErro, TipoErroDTO>(service.Conn);

                if (model == null || !model.Id.HasValue)
                {
                    throw new Exception("O registro para alteração informado não foi encontrado");
                }

                service.Atualizar(model);

                return Json(new { mensagem = "O registro foi alterado com sucesso" });
            }
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            using (TipoErroService service = new TipoErroService())
            {
                service.Excluir(id);

                return Json(new { mensagem = "O registro foi excluído com sucesso" });
            }
        }
    }
}
