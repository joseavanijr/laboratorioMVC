using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.EntityConfig
{
    public class PlanoDeSaudeConfiguration:EntityTypeConfiguration<PlanoDeSaude>
    {
        public PlanoDeSaudeConfiguration()
        {
            ToTable("PlanosDeSaude");
            HasKey(p => p.PlanoDeSaudeId);
            Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnType("varchar");
            
        }
    }
}
