using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class ServicoInstrutor{

        public int id { get; set; }

        public int idServico { get; set; }
        public virtual Servico Servico { get; set; }

        public int idInstrutor { get; set; }
        public virtual Usuario Instrutor { get; set; }

        public DateTime? dtExclusao { get; set; }
    }
    
    internal sealed class ServicoInstrutorMapper : EntityTypeConfiguration<ServicoInstrutor> {

        public ServicoInstrutorMapper() {
            this.ToTable("tb_servico_instrutor");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.Instrutor).WithMany().HasForeignKey(x => x.idInstrutor);
        }
    }
}