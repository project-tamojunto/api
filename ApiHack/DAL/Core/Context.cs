using System.Data.Entity;
using ApiHack.DAL.Entities;

namespace ApiHack.Models
{
    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<AgendaServico> AgendaServico { get; set; }
        public DbSet<AgendaUsuario> AgendaUsuario { get; set; }
        public DbSet<CategoriaServico> CategoriaServico { get; set; }
        public DbSet<InstrutorProfissao> InstrutorProfissao { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Profissao> Profissao { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ServicoInstrutor> ServicoInstrutor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<CategoriaServicoProfissao> CategoriaServicoProfissao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new ServicoMapper());
            modelBuilder.Configurations.Add(new AgendaServicoMapper());
            modelBuilder.Configurations.Add(new AgendaUsuarioMapper());
            modelBuilder.Configurations.Add(new CategoriaServicoMapper());
            modelBuilder.Configurations.Add(new InstrutorProfissaoMapper());
            modelBuilder.Configurations.Add(new TipoUsuarioMapper());
            modelBuilder.Configurations.Add(new ProfissaoMapper());
            modelBuilder.Configurations.Add(new ServicoInstrutorMapper());
            modelBuilder.Configurations.Add(new UsuarioMapper());
            modelBuilder.Configurations.Add(new CategoriaServicoProfissaoMapper());

        }
        
    }
}