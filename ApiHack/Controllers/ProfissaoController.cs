using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiHack.BLL;

namespace ApiHack.Controllers{
    public class ProfissaoController : ApiController{

        //Atributos
        private ProfissaoBL _ProfissaoBL;

        //Propriedades
        private ProfissaoBL OProfissaoBL => this._ProfissaoBL = this._ProfissaoBL ?? new ProfissaoBL();

        public async Task<HttpResponseMessage> Get(){

            var listaProfissoes = this.OProfissaoBL.listar().Select(x => new { x.id, x.descricao }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, listaProfissoes);
        }
    }
}
