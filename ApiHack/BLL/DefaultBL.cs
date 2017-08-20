using System;
using System.Security.Principal;
using ApiHack.Models;

namespace BLL.Services
{

    public class DefaultBL
    {

        //Atributos
        private Context _DataContext;

        //Propriedades
        public Context db => this._DataContext = this._DataContext ?? new Context();
    }
}