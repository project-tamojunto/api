using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHack.Models
{
    public class DefaultDTO
    {
        public object listaResultados { get; set; }
        public List<string> listaMensagens { get; set; }
        public bool flagErro { get; set; }

        public DefaultDTO(){
            this.listaMensagens = new List<string>();
        }
    }
}