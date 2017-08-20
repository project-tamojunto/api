using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class Servico{
        public int id { get; set; }

        public int idInstrutor { get; set; }
        public virtual Usuario Instrutor { get; set; }

        public int idCategoriaServico { get; set; }
        public virtual CategoriaServico CategoriaServico { get; set; }

        public string nome { get; set; }

        public decimal? preco { get; set; }

        public string descricao { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string servicosAdicionais { get; set; }

        public virtual List<AgendaServico> listaAgendaServico { get; set; }
    }
    
    internal sealed class ServicoMapper : EntityTypeConfiguration<Servico> {

        public ServicoMapper() {
            this.ToTable("tb_servico");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.Instrutor).WithMany().HasForeignKey(x => x.idInstrutor);

            this.HasRequired(x => x.CategoriaServico).WithMany().HasForeignKey(x => x.idCategoriaServico);
        }

    }
}