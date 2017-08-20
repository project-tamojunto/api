using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHack.DAL.Const{

    public class AgendaServicoCadastroDTO{

        public int idInstrutor { get; set; }

        public int idServico { get; set; }

        public string data { get; set; }

        public TimeSpan horarioIni { get; set; }

        public TimeSpan horarioFim { get; set; }

        public int qtdVagas { get; set; }
    }
}