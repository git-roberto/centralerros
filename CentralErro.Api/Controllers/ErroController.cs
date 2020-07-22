using CentralErro.Model;
using CentralErro.Service;
using CentralErro.Transport;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralErro.Api.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult Index()
        {
            using (ErroService service = new ErroService())
            {
                List<ErroDTO> lstRetorno = service.ListarDTO();

                return Json(new { resultado = lstRetorno, qtdRegistro = lstRetorno.Count() });
            }
        }

        public ActionResult Buscar(int id)
        {
            using (ErroService service = new ErroService())
            {
                ErroDTO retorno = service.Buscar(id).ToDTO<Erro, ErroDTO>();

                return Json(new { resultado = retorno });
            }
        }

        public ActionResult Incluir(ErroDTO registro)
        {
            using (ErroService service = new ErroService())
            {
                var model = registro.ToModel<Erro, ErroDTO>(service.Conn);

                service.Incluir(model);

                return Json(new { mensagem = "O registro foi incluído com sucesso" });
            }
        }

        public ActionResult Atualizar(ErroDTO registro)
        {
            using (ErroService service = new ErroService())
            {
                var model = registro.ToModel<Erro, ErroDTO>(service.Conn);

                if (model == null || !model.Id.HasValue)
                {
                    throw new Exception("O registro para alteração informado não foi encontrado");
                }

                service.Atualizar(model);

                return Json(new { mensagem = "O registro foi alterado com sucesso" });
            }
        }

        public ActionResult Excluir(int id)
        {
            using (ErroService service = new ErroService())
            {
                service.Excluir(id);

                return Json(new { mensagem = "O registro foi incluído com sucesso" });
            }
        }
    }
}
