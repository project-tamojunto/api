using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using ApiHack.BLL;
using ApiHack.DAL.Entities;

namespace WEB.Areas.Permissao.Helpers {
    public class CategoriaServicoHelper {

        //Atributos
        private static CategoriaServicoHelper _instance;
        private static CategoriaServicoBL _CategoriaServicoBL;

        //Propriedades
        public static CategoriaServicoHelper getInstance => _instance = _instance ?? new CategoriaServicoHelper();
        private static CategoriaServicoBL OCategoriaServicoBL => _CategoriaServicoBL = _CategoriaServicoBL ?? new CategoriaServicoBL();

        //
        public SelectList selectList(int? selected) {

            var query = OCategoriaServicoBL.listar();

            var lista = query.Select(x => new { x.id, x.descricao }).ToList();

            return new SelectList(lista, "id", "descricao", selected);
        }

    }
}