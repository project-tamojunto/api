using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class InstrutorProfissao{

        public int id { get; set; }

        public int idInstrutor { get; set; }
        public virtual Usuario Instrutor { get; set; }

        public int idProfissao { get; set; }
        public virtual Profissao Profissao { get; set; }

        public DateTime? dtExclusao { get; set; }
    }
    
    internal sealed class InstrutorProfissaoMapper : EntityTypeConfiguration<InstrutorProfissao> {

        public InstrutorProfissaoMapper() {
            this.ToTable("tb_instrutor_profissao");

            this.HasKey(x => x.id);

            this.HasRequired(x => x.Instrutor).WithMany(x => x.listaProfissoes).HasForeignKey(x => x.idInstrutor);

            this.HasRequired(x => x.Profissao).WithMany().HasForeignKey(x => x.idProfissao);
        }
    }
}