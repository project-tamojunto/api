using System;
using System.Security.Principal;
using ApiHack.DAL.Entities;

namespace WEB{

    public static class SecurityExtensions {

        //Verificar se há login ativo na pagina
        public static bool hasLogin(this IPrincipal User) {

            if (String.IsNullOrEmpty(SecurityCookie.userId) || String.IsNullOrEmpty(SecurityCookie.userName) || User.idPerfil() == 0) {

                return false;

            }

            return true;
        }

        //Configurar os cookies de seguranca a partir de um associado
        public static void signInFromEntity(this IPrincipal User, Usuario OUsuario) {

            SecurityCookie.userId = OUsuario.id.ToString();

            SecurityCookie.idPerfil = OUsuario.idTipoUsuario.ToString();

            SecurityCookie.userName = OUsuario.nome;

            //SecurityCookie.userEmail = OUsuario.e;


        }

        //Destruir os cookies de seguranca a partir de um associado
        public static void signOut(this IPrincipal User) {

            SecurityCookie.userId = null;

            SecurityCookie.idPerfil = null;

            SecurityCookie.userName = null;

            SecurityCookie.userEmail = null;
        }


        //
        public static int id(this IPrincipal User) {

            string idString = SecurityCookie.userId;

            if (string.IsNullOrEmpty(idString)){
                return 0;
            }

            string cookieUser = idString;

            return Convert.ToInt32(cookieUser);
        }

        //
        public static int idPerfil(this IPrincipal User) {

            string idString = SecurityCookie.idPerfil;

            if (string.IsNullOrEmpty(idString)){
                return 0;
            }

            string cookiePerfil = idString;

            return Convert.ToInt32(cookiePerfil);
        }

        //
        public static string name(this IPrincipal User) {
            return SecurityCookie.userName;
        }

        //
        public static string email(this IPrincipal User) {
            return SecurityCookie.userEmail;
        }
    }
}

