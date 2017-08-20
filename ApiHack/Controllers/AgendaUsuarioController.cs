using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ApiHack.BLL;
using ApiHack.DAL.Const;
using ApiHack.DAL.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiHack.Controllers{
    public class AgendaUsuarioController : ApiController{

        //Atributos
        private AgendaUsuarioBL _AgendaUsuarioBL;
        private AgendaServicoBL _AgendaServicoBL;

        //Propriedades
        private AgendaUsuarioBL OAgendaUsuarioBL => this._AgendaUsuarioBL = this._AgendaUsuarioBL ?? new AgendaUsuarioBL();
        private AgendaServicoBL OAgendaServicoBL => this._AgendaServicoBL = this._AgendaServicoBL ?? new AgendaServicoBL();

        [Route("api/AgendaUsuario/carregar/"), HttpGet]
        public async Task<HttpResponseMessage> carregar() {

            var idAgendaUsuario = UtilRequest.getInt32("idAgendaUsuario");

            var OAgendaUsuario = this.OAgendaUsuarioBL.listar().Select(x => new {
                x.id,
                x.idAgendaServico,
                x.idUsuario,
                x.flagRealizado,
                x.avaliacao,
                x.comentarioAvaliacao,
                nomeUsuario = x.Usuario.nome,
            }).Where(x => x.id == idAgendaUsuario);
            
            return Request.CreateResponse(HttpStatusCode.OK, OAgendaUsuario);
        }

        [Route("api/AgendaUsuario/listar/"), HttpGet]
        public async Task<HttpResponseMessage> listar(){

            var idAgendaServico = UtilRequest.getInt32("idAgendaServico");
            var idUsuario = UtilRequest.getInt32("idUsuario");

            var query = this.OAgendaUsuarioBL.listar(); 

            if (idAgendaServico > 0) {
                query = query.Where(x => x.idAgendaServico == idAgendaServico);
            }

            if (idUsuario > 0) {
                query = query.Where(x => x.idUsuario == idUsuario);
            }

            if (idAgendaServico == 0 && idUsuario == 0) {
                return Request.CreateResponse(HttpStatusCode.OK, new {});
            }

            var listaAgendaUsuario = query.Select(x => new {
                x.id,
                x.idAgendaServico,
                x.idUsuario,
                x.flagRealizado,
                x.avaliacao,
                x.comentarioAvaliacao, 
                nomeUsuario = x.Usuario.nome,
            }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, listaAgendaUsuario);
        }
        

        [HttpPost, Route("api/AgendaUsuario/cadastrar/")]
        public async Task<HttpResponseMessage> cadastrar(HttpRequestMessage request) {

            var jsonString = await request.Content.ReadAsStringAsync();
            
            try {
                var DadosServico = JsonConvert.DeserializeObject<AgendaUsuarioCadastroDTO>(jsonString, new IsoDateTimeConverter());

                var OAgendaUsuario = new AgendaUsuario();

                OAgendaUsuario.idAgendaServico = DadosServico.idAgendaServico;
                OAgendaUsuario.idUsuario = DadosServico.idUsuario;

                var OAgendaServico = OAgendaServicoBL.carregar(OAgendaUsuario.idAgendaServico);
                if (OAgendaServico.listaAgendaUsuario.Count + 1 > OAgendaServico.qtdVagas) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Não há mais vagas disponíveis" });
                }

                var flagSucesso = OAgendaUsuarioBL.salvar(OAgendaUsuario);
                if (flagSucesso) {
                    return Request.CreateResponse(HttpStatusCode.OK, OAgendaUsuario);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new {error = true, message = "Não foi possível realizar o cadastro"});

            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Ocorreu um erro inesperado" });
            }
        }
    }
}
