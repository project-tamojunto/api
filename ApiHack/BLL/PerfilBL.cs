using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class TipoUsuarioBL : DefaultBL{

        public TipoUsuario carregar(int id) {
           

            var query = from tb in db.TipoUsuario where tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<TipoUsuario> listar() {
            
            var query = from tb in db.TipoUsuario  select tb;

            return query;
        }

        public bool salvar(TipoUsuario OTipoUsuario) {

            if (OTipoUsuario.id > 0) {
                return this.atualizar(OTipoUsuario);
            }

            return this.inserir(OTipoUsuario);
        }

        public bool inserir(TipoUsuario OTipoUsuario) {

            db.TipoUsuario.Add(OTipoUsuario);

            db.SaveChanges();

            return OTipoUsuario.id > 0;
        }


        public bool atualizar(TipoUsuario OTipoUsuario) {

            var dbTipoUsuario = this.carregar(OTipoUsuario.id);

            if (dbTipoUsuario == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbTipoUsuario);
            entryVeiculo.CurrentValues.SetValues(OTipoUsuario);
            db.SaveChanges();

            return OTipoUsuario.id > 0;
        }
        
    }
}