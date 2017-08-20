using System;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class Profissao{

        public int id { get; set; }

        public string descricao { get; set; }

        public DateTime? dtExclusao { get; set; }
    }
    
    internal sealed class ProfissaoMapper : EntityTypeConfiguration<Profissao> {

        public ProfissaoMapper() {
            this.ToTable("tb_profissao");

            this.HasKey(x => x.id);
        }
    }
}