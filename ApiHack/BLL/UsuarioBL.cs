using System;
using System.Linq;
using ApiHack.DAL.Entities;
using BLL.Services;

namespace ApiHack.BLL{
    public class UsuarioBL : DefaultBL{

        public Usuario carregar(int id) {
           
            var query = from tb in db.Usuario where tb.id == id select tb;

            return query.FirstOrDefault();

        }

        public IQueryable<Usuario> listar() {
            
            var query = from tb in db.Usuario select tb;

            return query;
        }

        public bool salvar(Usuario OUsuario) {

            if (OUsuario.id > 0) {
                return this.atualizar(OUsuario);
            }

            return this.inserir(OUsuario);
        }

        public bool inserir(Usuario OUsuario) {

            db.Usuario.Add(OUsuario);

            db.SaveChanges();

            return OUsuario.id > 0;
        }


        public bool atualizar(Usuario OUsuario) {

            var dbUsuario = this.carregar(OUsuario.id);

            if (dbUsuario == null) {
                return false;
            }

            var entryVeiculo = db.Entry(dbUsuario);
            entryVeiculo.CurrentValues.SetValues(OUsuario);
            db.SaveChanges();

            return OUsuario.id > 0;
        }
        
        public Usuario login(string login, string senha) {

            var OUsuario = (from Usu in db.Usuario where
                              Usu.login == login &&
                              Usu.senha == senha
                            select Usu).FirstOrDefault();

            if (OUsuario == null) {
                return null;
            }

            return OUsuario;
        }
    }
}