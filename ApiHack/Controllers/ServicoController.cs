using System;
using System.Data.Entity;
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
    public class ServicoController : ApiController{

        //Atributos
        private ServicoBL _ServicoBL;
        private UsuarioBL _UsuarioBL;
        private CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        private ServicoBL OServicoBL => this._ServicoBL = this._ServicoBL ?? new ServicoBL();
        private UsuarioBL OUsuarioBL => this._UsuarioBL = this._UsuarioBL ?? new UsuarioBL();
        private CategoriaServicoBL OCategoriaServicoBL  => this._CategoriaServicoBL = this._CategoriaServicoBL ?? new CategoriaServicoBL();

        [Route("api/Servico/carregar/"), HttpGet]
        public async Task<HttpResponseMessage> carregar() {

            var idServico = UtilRequest.getInt32("idServico");

            var OServico = this.OServicoBL.listar().Where(x => x.id == idServico).Include(x => x.listaAgendaServico).Take(1).ToList().Select(x => new {
                x.id,
                x.nome,
                x.descricao,
                x.preco,
                nomeInstrutor = x.Instrutor?.nome,
                categoria = x.CategoriaServico?.descricao,
                x.latitude,
                x.longitude,
                x.servicosAdicionais,
                listaAgenda = x.listaAgendaServico?.Where(y => y.data > DateTime.Now).Select(y => new {
                    y.id,
                    data = y.data?.ToString("dd/MM/yyyy"),
                    horarioIni = y.horarioIni?.Hours.ToString().PadLeft(2, '0') + ":" + y.horarioIni?.Minutes.ToString().PadLeft(2, '0'),
                    horarioFim = y.horarioFim?.Hours.ToString().PadLeft(2, '0') + ":" + y.horarioFim?.Minutes.ToString().PadLeft(2, '0'),
                    y.qtdVagas, qtdOcupadas = y.listaAgendaUsuario?.Count
                }).ToList()
            }).FirstOrDefault();
            
            return Request.CreateResponse(HttpStatusCode.OK, OServico);
        }

        [Route("api/Servico/listar/"), HttpGet]
        public async Task<HttpResponseMessage> listar() {

            var flagTodas = UtilRequest.getBool("flagTodas");
            var idInstrutor = UtilRequest.getInt32("idInstrutor");

            var query = this.OServicoBL.listar();

            if (flagTodas != true) {
                query = query.Where(x => x.listaAgendaServico.Any(y => y.data >= DateTime.Now));
            }

            if (idInstrutor > 0) {
                query = query.Where(x => x.idInstrutor == idInstrutor);
            }

            var listaServicos = query.Include(x => x.listaAgendaServico).ToList().Select(x => new {
                    x.id,
                    x.nome,
                    x.descricao,
                    x.preco,
                    nomeInstrutor = x.Instrutor.nome,
                    categoria = x.CategoriaServico.descricao,
                    x.latitude,
                    x.longitude,
                    x.servicosAdicionais,
                    listaAgenda = x.listaAgendaServico?.Where(y => y.data > DateTime.Now).Select(y => new {
                        y.id,
                        data = y.data?.ToString("dd/MM/yyyy"),
                        horarioIni = y.horarioIni?.Hours.ToString().PadLeft(2, '0') + ":" + y.horarioIni?.Minutes.ToString().PadLeft(2, '0'),
                        horarioFim = y.horarioFim?.Hours.ToString().PadLeft(2, '0') + ":" + y.horarioFim?.Minutes.ToString().PadLeft(2, '0'),
                        y.qtdVagas,
                        qtdOcupadas = y.listaAgendaUsuario?.Count
                    }).ToList()
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listaServicos);
        }

        [Route("api/Servico/listarMapa/"), HttpGet]
        public async Task<HttpResponseMessage> listarMapa(){

            var listaCategoria = this.OServicoBL.listar().Where(x => x.listaAgendaServico.Any(y => y.data >= DateTime.Now))
                .Select(x => new {
                    x.id,
                    categoria = x.CategoriaServico.descricao,
                    x.longitude,
                    x.latitude,
                    x.nome
                }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listaCategoria);
        }

        [Route("api/Servico/getPreco/"), HttpGet]
        public async Task<HttpResponseMessage> getPreco(){

            var idServico = UtilRequest.getInt32("idServico");

            var preco = this.OServicoBL.carregar(idServico).preco;

            return Request.CreateResponse(HttpStatusCode.OK, preco);
        }

        [HttpPost, Route("api/Servico/cadastrar/")]
        public async Task<HttpResponseMessage> cadastrar(HttpRequestMessage request) {

            var jsonString = await request.Content.ReadAsStringAsync();

            var OServico = new Servico();

            try {
                
                var DadosServico = JsonConvert.DeserializeObject<ServicoCadastroDTO>(jsonString, new IsoDateTimeConverter());
                
                OServico.latitude = DadosServico.latitude;
                OServico.longitude = DadosServico.longitude;
                OServico.descricao = DadosServico.descricao;
                OServico.nome = DadosServico.nome;
                OServico.idCategoriaServico = DadosServico.idCategoriaServico;
                OServico.servicosAdicionais = DadosServico.servicosAdicionais;
                OServico.idInstrutor = DadosServico.idInstrutor;
                OServico.preco = DadosServico.preco;

                var OInstrutor = OUsuarioBL.listar().FirstOrDefault(x => x.id == OServico.idInstrutor && x.idTipoUsuario == PerfilConst.INSTRUTOR);
                if (OInstrutor == null) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "O instrutor não pode ser localizado" });
                }

                if (OInstrutor.flagValidado != true && OInstrutor.flagProfissional == true) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "O seu usuario esta em validação no momento, aguarde até ser liberado para cadastrar serviços" });
                }

                var OCategoria = OCategoriaServicoBL.carregar(OServico.idCategoriaServico);
                if (OCategoria == null) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "O instrutor não pode ser localizado" });
                }

                var idsProfissaoInstrutura = OInstrutor.listaProfissoes.Select(x => x.idProfissao).ToList();
                if (!OCategoria.listaProfissao.Any(x => idsProfissaoInstrutura.Contains(x.idProfissao)) && OInstrutor.flagProfissional == true) {
                    return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "A suas profissões não condiz com a categoria do serviço" });
                }
                
                var flagSucesso = OServicoBL.salvar(OServico);
                if (flagSucesso) {
                    return Request.CreateResponse(HttpStatusCode.OK, OServico);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new {error = true, message = "Não foi possível realizar o cadastro"});


            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Ocorreu um erro inesperado" });
            }
        }
    }
}
