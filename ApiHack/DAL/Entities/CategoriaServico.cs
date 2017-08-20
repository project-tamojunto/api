using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ApiHack.DAL.Entities{

    public class CategoriaServico{

        public int id { get; set; }

        public string descricao { get; set; }

        public virtual List<CategoriaServicoProfissao> listaProfissao { get; set; }

        public DateTime? dtExclusao { get; set; }
    }
    
    internal sealed class CategoriaServicoMapper : EntityTypeConfiguration<CategoriaServico> {

        public CategoriaServicoMapper() {
            this.ToTable("tb_categoria_servico");

            this.HasKey(x => x.id);
        }
    }
}