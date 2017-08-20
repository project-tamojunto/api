using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class CategoriaServicoProfissao{

        public int id { get; set; }

        public int idCategoriaServico { get; set; }
        public virtual CategoriaServico CategoriaServico { get; set; }

        public int idProfissao { get; set; }
        public virtual Profissao Profissao { get; set; }
    }
    
    internal sealed class CategoriaServicoProfissaoMapper : EntityTypeConfiguration<CategoriaServicoProfissao> {

        public CategoriaServicoProfissaoMapper() {
            this.ToTable("tb_categoria_servico_profissao");
            
            this.HasKey(x => x.id);

            this.HasRequired(x => x.CategoriaServico).WithMany(x => x.listaProfissao).HasForeignKey(x => x.idCategoriaServico);

            this.HasRequired(x => x.Profissao).WithMany().HasForeignKey(x => x.idProfissao);
        }
    }
}