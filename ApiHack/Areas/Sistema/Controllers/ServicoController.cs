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
    public class ServicoController : Controller{

        //Atributos
        private ServicoBL _ServicoBL;
        private UsuarioBL _UsuarioBL;
        private CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        private ServicoBL OServicoBL => this._ServicoBL = this._ServicoBL ?? new ServicoBL();
        private UsuarioBL OUsuarioBL => this._UsuarioBL = this._UsuarioBL ?? new UsuarioBL();
        private CategoriaServicoBL OCategoriaServicoBL => this._CategoriaServicoBL = this._CategoriaServicoBL ?? new CategoriaServicoBL();


        public ActionResult Index() {

            var idUSuario = User.id();

            var lista = OServicoBL.listar().Where(x => x.idInstrutor == idUSuario).ToList();

            return View(lista);
        }

        public ActionResult editar(int? id) {


            var OServico = OServicoBL.carregar(Convert.ToInt32(id)) ?? new Servico();


            return View(OServico);
        }

        [HttpPost]
        public ActionResult editar(Servico ViewModel) {

            var idUsuario = User.id();
            ViewModel.idInstrutor = idUsuario;

            var salvar = OServicoBL.salvar(ViewModel);

            return RedirectToAction("index");
        }

    }
}