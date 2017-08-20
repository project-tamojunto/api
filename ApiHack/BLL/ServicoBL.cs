using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;
using System.Data.Entity;

namespace ApiHack.BLL{
    public class ServicoBL : DefaultBL{

        public Servico carregar(int id) {
           
            var query = from tb in db.Servico
                            .Include(x => x.CategoriaServico)
                        where tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<Servico> listar() {
            
            var query = from tb in db.Servico select tb;
                
            return query;
        }

        public bool salvar(Servico OServico) {

            if (OServico.id > 0) {
                return this.atualizar(OServico);
            }

            return this.inserir(OServico);
        }

        public bool inserir(Servico OServico) {

            db.Servico.Add(OServico);

            db.SaveChanges();

            return OServico.id > 0;
        }


        public bool atualizar(Servico OServico) {

            var dbServico = this.carregar(OServico.id);

            if (dbServico == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbServico);
            entryVeiculo.CurrentValues.SetValues(OServico);
            db.SaveChanges();

            return OServico.id > 0;
        }      
    }
}