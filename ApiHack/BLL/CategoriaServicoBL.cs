using System;
using System.Data.Entity;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class CategoriaServicoBL : DefaultBL{

        public CategoriaServico carregar(int id) {
           
            var query = from tb in db.CategoriaServico
                            .Include(x => x.listaProfissao)
                        where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();
        }

        public IQueryable<CategoriaServico> listar() {
            
            var query = from tb in db.CategoriaServico where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(CategoriaServico OCategoriaServico) {

            if (OCategoriaServico.id > 0) {
                return this.atualizar(OCategoriaServico);
            }

            return this.inserir(OCategoriaServico);
        }

        public bool inserir(CategoriaServico OCategoriaServico) {

            db.CategoriaServico.Add(OCategoriaServico);

            db.SaveChanges();

            return OCategoriaServico.id > 0;
        }


        public bool atualizar(CategoriaServico OCategoriaServico) {

            var dbCategoriaServico = this.carregar(OCategoriaServico.id);

            if (dbCategoriaServico == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbCategoriaServico);
            entryVeiculo.CurrentValues.SetValues(OCategoriaServico);
            db.SaveChanges();

            return OCategoriaServico.id > 0;
        }
        
        public bool excluir(int id) {
            var CategoriaServico = this.carregar(id);

            if (CategoriaServico == null) {
                return false;
            }

            try {

                CategoriaServico.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}