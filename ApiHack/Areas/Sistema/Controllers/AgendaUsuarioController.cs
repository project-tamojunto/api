using System;
using System.Linq;
using System.Web.Mvc;
using ApiHack.BLL;
using WEB;

namespace ApiHack.Areas.Sistema.Controllers{
    public class AgendaUsuarioController : Controller{

        //Atributos
        private AgendaUsuarioBL _AgendaUsuarioBL;

        //Propriedades
        private AgendaUsuarioBL OAgendaUsuarioBL => this._AgendaUsuarioBL = this._AgendaUsuarioBL ?? new AgendaUsuarioBL();


        public ActionResult Index() {

            var idUsuario = User.id();

            var lista = OAgendaUsuarioBL.listar().Where(x => x.AgendaServico.Servico.idInstrutor == idUsuario && x.AgendaServico.data >= DateTime.Now).OrderBy(x => x.AgendaServico.data).ToList();

            return View(lista);
        }
    }
}