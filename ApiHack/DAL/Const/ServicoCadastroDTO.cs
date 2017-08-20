using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHack.DAL.Const{

    public class ServicoCadastroDTO{
        
        public int idCategoriaServico { get; set; }

        public string nome { get; set; }

        public decimal preco { get; set; }

        public string descricao { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string servicosAdicionais { get; set; }

        public int idInstrutor { get; set; }

    }
}