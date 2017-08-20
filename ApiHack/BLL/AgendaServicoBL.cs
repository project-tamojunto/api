using System;
using System.Data.Entity;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class AgendaServicoBL : DefaultBL{

        public AgendaServico carregar(int id) {
           
            var query = from tb in db.AgendaServico
                        where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<AgendaServico> listar() {
            
            var query = from tb in db.AgendaServico
                        where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(AgendaServico OAgendaServico) {

            if (OAgendaServico.id > 0) {
                return this.atualizar(OAgendaServico);
            }

            return this.inserir(OAgendaServico);
        }

        public bool inserir(AgendaServico OAgendaServico) {

            db.AgendaServico.Add(OAgendaServico);

            db.SaveChanges();

            return OAgendaServico.id > 0;
        }


        public bool atualizar(AgendaServico OAgendaServico) {

            var dbAgendaServico = this.carregar(OAgendaServico.id);

            if (dbAgendaServico == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbAgendaServico);
            entryVeiculo.CurrentValues.SetValues(OAgendaServico);
            db.SaveChanges();

            return OAgendaServico.id > 0;
        }
        
        public bool excluir(int id) {
            var AgendaServico = this.carregar(id);

            if (AgendaServico == null) {
                return false;
            }

            try {

                AgendaServico.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}