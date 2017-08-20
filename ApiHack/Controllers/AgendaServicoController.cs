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
    public class AgendaServicoController : ApiController{

        //Atributos
        private AgendaServicoBL _AgendaServicoBL;

        //Propriedades
        private AgendaServicoBL OAgendaServicoBL => this._AgendaServicoBL = this._AgendaServicoBL ?? new AgendaServicoBL();

        [Route("api/AgendaServico/carregar/"), HttpGet]
        public async Task<HttpResponseMessage> carregar() {

            var idAgendaServico = UtilRequest.getInt32("idAgendaServico");

            var OAgendaServico = this.OAgendaServicoBL.listar().Where(x => x.id == idAgendaServico).Take(1).ToList().Select(x => new {
                x.id,
                data = x.data?.ToString("dd/MM/yyyy"),
                horarioIni = x.horarioIni?.Hours.ToString().PadLeft(2, '0') + ":" + x.horarioIni?.Minutes.ToString().PadLeft(2, '0'),
                horarioFim = x.horarioFim?.Hours.ToString().PadLeft(2, '0') + ":" + x.horarioFim?.Minutes.ToString().PadLeft(2, '0'),
                x.qtdVagas,
                servico = new {
                    x.Servico.nome,
                    x.Servico.descricao,
                    x.Servico.preco,
                    nomeInstrutor = x.Servico.Instrutor.nome,
                    categoria = x.Servico.CategoriaServico.descricao,
                    x.Servico.latitude,
                    x.Servico.longitude,
                    x.Servico.servicosAdicionais,
                },
                qtdUtilizada = x.listaAgendaUsuario.Count
            }).FirstOrDefault();
            
            return Request.CreateResponse(HttpStatusCode.OK, OAgendaServico);
        }

        [Route("api/AgendaServico/listar/"), HttpGet]
        public async Task<HttpResponseMessage> listar(){

            var idServico = UtilRequest.getInt32("idServico");

            var listaAgendaServico = this.OAgendaServicoBL.listar().Where(x => x.idServico == idServico).ToList()
                .Select(x => new {
                    x.id,
                    data = x.data?.ToString("dd/MM/yyyy"),
                    horarioIni = x.horarioIni?.Hours.ToString().PadLeft(2, '0') + ":" + x.horarioIni?.Minutes.ToString().PadLeft(2, '0'),
                    horarioFim = x.horarioFim?.Hours.ToString().PadLeft(2, '0') + ":" + x.horarioFim?.Minutes.ToString().PadLeft(2, '0'),
                    x.qtdVagas,
                    qtdUtilizada = x.listaAgendaUsuario.Count
                }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listaAgendaServico);
        }

        [HttpPost, Route("api/AgendaServico/cadastrar/")]
        public async Task<HttpResponseMessage> cadastrar(HttpRequestMessage request) {

            var jsonString = await request.Content.ReadAsStringAsync();
            
            try {
                var DadosServico = JsonConvert.DeserializeObject<AgendaServicoCadastroDTO>(jsonString, new IsoDateTimeConverter());

                var OAgendaServico = new AgendaServico();

                OAgendaServico.horarioIni = DadosServico.horarioIni;
                OAgendaServico.horarioFim = DadosServico.horarioFim;
                OAgendaServico.idServico = DadosServico.idServico;

                DateTime data;
                if (DateTime.TryParse(DadosServico.data, out data)) {
                    OAgendaServico.data = data;
                }
                
                OAgendaServico.qtdVagas = DadosServico.qtdVagas;
                
                var flagSucesso = OAgendaServicoBL.salvar(OAgendaServico);
                if (flagSucesso) {
                    return Request.CreateResponse(HttpStatusCode.OK, OAgendaServico);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new {error = true, message = "Não foi possível realizar o cadastro"});

            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Ocorreu um erro inesperado" });
            }
        }
    }
}
