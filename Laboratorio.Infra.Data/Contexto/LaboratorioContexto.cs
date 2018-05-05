using System.Data.Entity;
using Laboratorio.Domain.Entities;

namespace Laboratorio.Infra.Data.Contexto
{
    public class LaboratorioContexto: DbContext
    {
        public LaboratorioContexto()
            : base("ConexaoLaboratorio")
        {
                
        }

        private DbSet<Cidade> Cidades { get; set; }
        private DbSet<Atendimento> Atendimentos { get; set; }
        private DbSet<Exame> Exames { get; set; }
        private DbSet<ExamesDoAtendimento> ExamesDoAtendimento { get; set; }
        private DbSet<Paciente> Pacientes { get; set; }
    }
}
