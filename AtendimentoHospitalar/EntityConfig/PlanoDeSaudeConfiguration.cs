using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Property(p => p.PlanoDeSaudeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Descricao)
                .HasMaxLength(50)
                .IsRequired();
            
        }
    }
}
