using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class ServicoInstrutorBL : DefaultBL{

        public ServicoInstrutor carregar(int id) {
           
            var query = from tb in db.ServicoInstrutor where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<ServicoInstrutor> listar() {
            
            var query = from tb in db.ServicoInstrutor where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(ServicoInstrutor OServicoInstrutor) {

            if (OServicoInstrutor.id > 0) {
                return this.atualizar(OServicoInstrutor);
            }

            return this.inserir(OServicoInstrutor);
        }

        public bool inserir(ServicoInstrutor OServicoInstrutor) {

            db.ServicoInstrutor.Add(OServicoInstrutor);

            db.SaveChanges();

            return OServicoInstrutor.id > 0;
        }


        public bool atualizar(ServicoInstrutor OServicoInstrutor) {

            var dbServicoInstrutor = this.carregar(OServicoInstrutor.id);

            if (dbServicoInstrutor == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbServicoInstrutor);
            entryVeiculo.CurrentValues.SetValues(OServicoInstrutor);
            db.SaveChanges();

            return OServicoInstrutor.id > 0;
        }
        
        public bool excluir(int id) {
            var ServicoInstrutor = this.carregar(id);

            if (ServicoInstrutor == null) {
                return false;
            }

            try {

                ServicoInstrutor.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}