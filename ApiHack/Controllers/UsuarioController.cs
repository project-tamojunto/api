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
    public class UsuarioController : ApiController{

        //Atributos
        private UsuarioBL _UsuarioBL;

        //Propriedades
        private UsuarioBL OUsuarioBL => this._UsuarioBL = this._UsuarioBL ?? new UsuarioBL();

        [Route("api/Usuario/carregar/"), HttpGet]
        public async Task<HttpResponseMessage> carregar() {

            var idUsuario = UtilRequest.getInt32("idUsuario");

            var OUsuario = this.OUsuarioBL.carregar(idUsuario) ?? new Usuario();
            
            return Request.CreateResponse(HttpStatusCode.OK, OUsuario);
        }

        [Route("api/Usuario/listarInstrutores/"), HttpGet]
        public async Task<HttpResponseMessage> listarInstrutores(){

            var listaCategoria = this.OUsuarioBL.listar().Where(x => x.idTipoUsuario == PerfilConst.INSTRUTOR)
                .Select(x => new {
                    x.id,
                    x.nome,
                    x.flagProfissional,
                    x.nroTelefone,
                    x.nroCelular,
                    listaProfissoes = x.listaProfissoes.Select(y => new {
                        y.idProfissao,
                        y.Profissao.descricao
                    })
                }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listaCategoria);
        }

        [Route("api/Usuario/listarClientes/"), HttpGet]
        public async Task<HttpResponseMessage> listarUsuarios(){

            var listaCategoria = this.OUsuarioBL.listar().Where(x => x.idTipoUsuario == PerfilConst.CLIENTE)
                .Select(x => new {
                    x.id,
                    x.nome,
                    x.nroTelefone,
                    x.nroCelular,
                    x.meuPerfil,
                    x.nroDocumento,
                    x.rg
                }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, listaCategoria);
        }

        [HttpPost, Route("api/Usuario/cadastrarInstrutor/")]
        public async Task<HttpResponseMessage> cadastrarInstrutor(HttpRequestMessage request) {

            var jsonString = await request.Content.ReadAsStringAsync();

            try {
                
                var DadosUsuario = JsonConvert.DeserializeObject<UsuarioCadastroDTO>(jsonString, new IsoDateTimeConverter());

                var OUsuario = new Usuario();

                OUsuario.idTipoUsuario = PerfilConst.INSTRUTOR;
                OUsuario.flagValidado = true;
                OUsuario.nome = DadosUsuario.nome;
                OUsuario.meuPerfil = DadosUsuario.meuPerfil;
                OUsuario.flagPessoaJuridica = DadosUsuario.flagPessoaJuridica;
                OUsuario.flagProfissional = DadosUsuario.flagProfissional;
                OUsuario.nroCelular = DadosUsuario.nroCelular;
                OUsuario.nroTelefone = DadosUsuario.nroTelefone;
                OUsuario.nroDocumento = DadosUsuario.nroDocumento;

                OUsuario.listaProfissoes = DadosUsuario.idsProfissao.Select(x => new InstrutorProfissao() {
                    idProfissao = x
                }).ToList();
                
                var flagSucesso = OUsuarioBL.salvar(OUsuario);
                if (flagSucesso) {
                    return Request.CreateResponse(HttpStatusCode.OK, OUsuario);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new {error = true, message = "Não foi possível realizar o cadastro"});

            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Ocorreu um erro inesperado" });
            }
        }

        [HttpPost, Route("api/Usuario/cadastrarUsuario/")]
        public async Task<HttpResponseMessage> cadastrarUsuario(HttpRequestMessage request) {

            var jsonString = await request.Content.ReadAsStringAsync();

            try {
                
                var DadosUsuario = JsonConvert.DeserializeObject<UsuarioCadastroDTO>(jsonString, new IsoDateTimeConverter());

                var OUsuario = new Usuario();

                OUsuario.idTipoUsuario = PerfilConst.CLIENTE;
                OUsuario.nome = DadosUsuario.nome;
                OUsuario.meuPerfil = DadosUsuario.meuPerfil;
                OUsuario.nroCelular = DadosUsuario.nroCelular;
                OUsuario.nroTelefone = DadosUsuario.nroCelular;
                OUsuario.nroDocumento = DadosUsuario.nroDocumento;
                
                var flagSucesso = OUsuarioBL.salvar(OUsuario);
                if (flagSucesso) {
                    return Request.CreateResponse(HttpStatusCode.OK, OUsuario);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new {error = true, message = "Não foi possível realizar o cadastro"});

            } catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.OK, new { error = true, message = "Ocorreu um erro inesperado" });
            }
        }
    }
}
