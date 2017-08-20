using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHack.DAL.Const{

    public class UsuarioCadastroDTO{

        public bool flagPessoaJuridica { get; set; }

        public bool flagProfissional { get; set; }

        public string nome { get; set; }

        public string meuPerfil { get; set; }

        public string nroDocumento { get; set; }

        public string rg { get; set; }

        public string nroCelular { get; set; }

        public string nroTelefone { get; set; }

        public List<int> idsProfissao { get; set; }

    }
}