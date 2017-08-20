using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiHack.BLL;
using ApiHack.DAL.Entities;

namespace ApiHack.Controllers{
    public class CategoriaServicoController : ApiController{

        //Atributos
        private CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        private CategoriaServicoBL OCategoriaServicoBL => this._CategoriaServicoBL = this._CategoriaServicoBL ?? new CategoriaServicoBL();

        [Route("api/CategoriaServico/carregar/"), HttpGet]
        public async Task<HttpResponseMessage> carregar() {

            var idCategoria = UtilRequest.getInt32("idCategoria");

            var OCategoria = this.OCategoriaServicoBL.carregar(idCategoria) ?? new CategoriaServico();
            
            return Request.CreateResponse(HttpStatusCode.OK, OCategoria);
        }

        [Route("api/CategoriaServico/listar/"), HttpGet]
        public async Task<HttpResponseMessage> listar(){

            var listaCategoria = this.OCategoriaServicoBL.listar().Select(x => new { x.id, x.descricao }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, listaCategoria);
        }
    }
}
