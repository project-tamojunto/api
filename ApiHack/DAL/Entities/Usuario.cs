using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class Usuario{

        public int id { get; set; }

        public int idTipoUsuario { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }

        public bool flagPessoaJuridica { get; set; }

        public bool flagProfissional { get; set; }

        public string nome { get; set; }

        public string meuPerfil { get; set; }

        public string nroDocumento { get; set; }

        public string rg { get; set; }

        public string nroCelular { get; set; }

        public string nroTelefone { get; set; }

        public bool? flagValidado { get; set; }

        public string login { get; set; }

        public  string senha { get; set; }

        public virtual List<InstrutorProfissao> listaProfissoes { get; set; }
    }
    
    internal sealed class UsuarioMapper : EntityTypeConfiguration<Usuario> {

        public UsuarioMapper() {
            this.ToTable("tb_usuario");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.TipoUsuario).WithMany().HasForeignKey(x => x.idTipoUsuario);
        }
    }
}