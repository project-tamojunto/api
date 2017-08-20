using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiHack.BLL;
using ApiHack.DAL.Entities;
using WEB;

namespace ApiHack.Areas.Sistema.Controllers{
    public class AgendaServicoController : Controller{

        //Atributos
        private ServicoBL _ServicoBL;
        private UsuarioBL _UsuarioBL;
        private AgendaServicoBL _AgendaServicoBL;
        private CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        private ServicoBL OServicoBL => this._ServicoBL = this._ServicoBL ?? new ServicoBL();
        private UsuarioBL OUsuarioBL => this._UsuarioBL = this._UsuarioBL ?? new UsuarioBL();
        private AgendaServicoBL OAgendaServicoBL => this._AgendaServicoBL = this._AgendaServicoBL ?? new AgendaServicoBL();
        private CategoriaServicoBL OCategoriaServicoBL => this._CategoriaServicoBL = this._CategoriaServicoBL ?? new CategoriaServicoBL();


        public ActionResult Index(int? idServico) {

            idServico = Convert.ToInt32(idServico);

            var lista = OAgendaServicoBL.listar().Where(x => x.idServico == idServico).ToList();

            return View(lista);
        }

        public ActionResult editar(int? id, int? idServico) {

            var OServico = OAgendaServicoBL.carregar(Convert.ToInt32(id)) ?? new AgendaServico();

            OServico.idServico = OServico.idServico > 0 ? OServico.idServico : idServico;

            return View(OServico);
        }

        [HttpPost]
        public ActionResult editar(AgendaServico ViewModel) {

            var idUsuario = User.id();

            var salvar = OAgendaServicoBL.salvar(ViewModel);

            return RedirectToAction("index", new {idServico = ViewModel.idServico});
        }
    }
}