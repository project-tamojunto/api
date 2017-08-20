using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class AgendaUsuarioBL : DefaultBL{

        public AgendaUsuario carregar(int id) {
           
            var query = from tb in db.AgendaUsuario where tb.dtExclusao == null && tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<AgendaUsuario> listar() {
            
            var query = from tb in db.AgendaUsuario where tb.dtExclusao == null select tb;

            return query;
        }

        public bool salvar(AgendaUsuario OAgendaUsuario) {

            if (OAgendaUsuario.id > 0) {
                return this.atualizar(OAgendaUsuario);
            }

            return this.inserir(OAgendaUsuario);
        }

        public bool inserir(AgendaUsuario OAgendaUsuario) {

            db.AgendaUsuario.Add(OAgendaUsuario);

            db.SaveChanges();

            return OAgendaUsuario.id > 0;
        }


        public bool atualizar(AgendaUsuario OAgendaUsuario) {

            var dbAgendaUsuario = this.carregar(OAgendaUsuario.id);

            if (dbAgendaUsuario == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbAgendaUsuario);
            entryVeiculo.CurrentValues.SetValues(OAgendaUsuario);
            db.SaveChanges();

            return OAgendaUsuario.id > 0;
        }
        
        public bool excluir(int id) {
            var AgendaUsuario = this.carregar(id);

            if (AgendaUsuario == null) {
                return false;
            }

            try {

                AgendaUsuario.dtExclusao = DateTime.Now;

                db.SaveChanges();

                return true;

            } catch (Exception) {
                return false;
            }
        }
    }
}