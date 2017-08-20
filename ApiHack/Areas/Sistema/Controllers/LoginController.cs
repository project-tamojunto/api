using System;
using System.Web.Mvc;
using ApiHack.Areas.Sistema.Models;
using ApiHack.BLL;
using ApiHack.DAL.Const;
using ApiHack.DAL.Entities;
using MvcFlashMessages;
using WEB;

namespace ApiHack.Areas.Sistema.Controllers{
    [AllowAnonymous]
    public class LoginController : Controller{

        //Atributos
        private UsuarioBL _UsuarioBL;

        // Propriedades
        private UsuarioBL OUsuarioBL => (this._UsuarioBL = this._UsuarioBL ?? new UsuarioBL());

        public ActionResult Index(string returnUrl){
            var ViewModel = new LoginVM();

            ViewModel.returnUrl = returnUrl;

            return View(ViewModel);
        }

        //POST
		[HttpPost]
		public ActionResult index(LoginVM ViewModel){ 

			if (!ModelState.IsValid) {

				return PartialView(ViewModel);
			}
			
			var OUsuario = OUsuarioBL.login(ViewModel.login, ViewModel.senha);

			if (OUsuario == null) {

				this.Flash("ERROR", "Acesso negado");

				return PartialView(ViewModel);

			}

			User.signInFromEntity(OUsuario);

            string urlRedirecionamento = String.IsNullOrEmpty(ViewModel.returnUrl)? Url.Action("index", "home", new {area = "Sistema"}) : ViewModel.returnUrl;

			return Redirect(urlRedirecionamento);
		}

        [HttpGet]
        public ActionResult cadastrar() {

            var OServico = new Usuario();

            return View(OServico);
        }

        [HttpPost]
        public ActionResult cadastrar(Usuario ViewModel) {

            ViewModel.idTipoUsuario = PerfilConst.INSTRUTOR;

            var salvar = OUsuarioBL.salvar(ViewModel);

            return RedirectToAction("index");
        }

        		//GET
		[HttpGet]
		public ActionResult sair(){

		    User.signOut();

            return RedirectToAction("index");
		}
    }
}