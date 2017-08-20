using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class ProfissaoBL : DefaultBL{

        public Profissao carregar(int id) {
           
            var query = from tb in db.Profissao where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<Profissao> listar() {
            
            var query = from tb in db.Profissao where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(Profissao OProfissao) {

            if (OProfissao.id > 0) {
                return this.atualizar(OProfissao);
            }

            return this.inserir(OProfissao);
        }

        public bool inserir(Profissao OProfissao) {

            db.Profissao.Add(OProfissao);

            db.SaveChanges();

            return OProfissao.id > 0;
        }


        public bool atualizar(Profissao OProfissao) {

            var dbProfissao = this.carregar(OProfissao.id);

            if (dbProfissao == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbProfissao);
            entryVeiculo.CurrentValues.SetValues(OProfissao);
            db.SaveChanges();

            return OProfissao.id > 0;
        }
        
        public bool excluir(int id) {
            var Profissao = this.carregar(id);

            if (Profissao == null) {
                return false;
            }

            try {

                Profissao.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}