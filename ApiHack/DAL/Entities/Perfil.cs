using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class TipoUsuario{

        public int id { get; set; }

        public string descricao { get; set; }
    }
    
    internal sealed class TipoUsuarioMapper : EntityTypeConfiguration<TipoUsuario> {

        public TipoUsuarioMapper() {
            this.ToTable("tb_tipo_usuario");

            this.HasKey(x => x.id);   
        }
    }
}