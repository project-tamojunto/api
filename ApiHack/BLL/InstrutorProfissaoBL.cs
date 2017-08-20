using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class InstrutorProfissaoBL : DefaultBL{

        public InstrutorProfissao carregar(int id) {
           
            var query = from tb in db.InstrutorProfissao where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<InstrutorProfissao> listar() {
            
            var query = from tb in db.InstrutorProfissao where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(InstrutorProfissao OInstrutorProfissao) {

            if (OInstrutorProfissao.id > 0) {
                return this.atualizar(OInstrutorProfissao);
            }

            return this.inserir(OInstrutorProfissao);
        }

        public bool inserir(InstrutorProfissao OInstrutorProfissao) {

            db.InstrutorProfissao.Add(OInstrutorProfissao);

            db.SaveChanges();

            return OInstrutorProfissao.id > 0;
        }


        public bool atualizar(InstrutorProfissao OInstrutorProfissao) {

            var dbInstrutorProfissao = this.carregar(OInstrutorProfissao.id);

            if (dbInstrutorProfissao == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbInstrutorProfissao);
            entryVeiculo.CurrentValues.SetValues(OInstrutorProfissao);
            db.SaveChanges();

            return OInstrutorProfissao.id > 0;
        }
        
        public bool excluir(int id) {
            var InstrutorProfissao = this.carregar(id);

            if (InstrutorProfissao == null) {
                return false;
            }

            try {

                InstrutorProfissao.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}