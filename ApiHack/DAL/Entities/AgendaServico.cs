using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class AgendaServico{

        public int id { get; set; }

        public int? idServico { get; set; }
        public virtual Servico Servico { get; set; }

        public DateTime? data { get; set; }

        public TimeSpan? horarioIni { get; set; }

        public TimeSpan? horarioFim { get; set; }

        public int? qtdVagas { get; set; }

        public DateTime? dtExclusao { get; set; }

        public virtual List<AgendaUsuario> listaAgendaUsuario { get; set; }
    }
    
    internal sealed class AgendaServicoMapper : EntityTypeConfiguration<AgendaServico> {

        public AgendaServicoMapper() {
            this.ToTable("tb_agenda_servico");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.Servico).WithMany(x => x.listaAgendaServico).HasForeignKey(x => x.idServico);
        }
    }
}