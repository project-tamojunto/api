using System.Linq;
using ApiHack.BLL;

namespace ApiHack.Models{
    public class CategoriaServicoListaVM{
        
        //Atributos
        private CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        private CategoriaServicoBL OCategoriaServicoBL => this._CategoriaServicoBL = this._CategoriaServicoBL ?? new CategoriaServicoBL();
    }
}