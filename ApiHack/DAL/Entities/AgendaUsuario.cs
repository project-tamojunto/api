using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class AgendaUsuario{

        public int id { get; set; }

        public int idUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int idAgendaServico { get; set; }
        public virtual AgendaServico AgendaServico { get; set; }

        public bool? flagRealizado { get; set; }

        public decimal? avaliacao { get; set; }

        public string comentarioAvaliacao { get; set; }

        public DateTime? dtCancelamento { get; set; }

        public DateTime? dtExclusao { get; set; }
    }
    
    internal sealed class AgendaUsuarioMapper : EntityTypeConfiguration<AgendaUsuario> {

        public AgendaUsuarioMapper() {
            this.ToTable("tb_agenda_usuario");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.idUsuario);
            this.HasRequired(x => x.AgendaServico).WithMany(x => x.listaAgendaUsuario).HasForeignKey(x => x.idAgendaServico);
        }
    }
}