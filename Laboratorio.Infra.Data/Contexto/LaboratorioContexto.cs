using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Laboratorio.Domain.Entities;
using Laboratorio.Infra.Data.EntityConfig;

namespace Laboratorio.Infra.Data.Contexto
{
    public class LaboratorioContexto: DbContext
    {
        public LaboratorioContexto()
            : base("ConexaoLaboratorio")
        {
                
        }

        private DbSet<Atendimento> Atendimentos { get; set; }
        private DbSet<Cidade> Cidades { get; set; }   
        private DbSet<Exame> Exames { get; set; }
        private DbSet<ExamesDoAtendimento> ExamesDoAtendimento { get; set; }
        private DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p=>p.Name==p.ReflectedType.Name+"Id")
                .Configure(p=>p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p=>p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p=>p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PlanoDeSaudeConfiguration());
            modelBuilder.Configurations.Add(new PacienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
