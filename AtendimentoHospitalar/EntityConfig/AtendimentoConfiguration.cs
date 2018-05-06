using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.EntityConfig
{
    public class AtendimentoConfiguration : EntityTypeConfiguration<Atendimento>
    {
        public AtendimentoConfiguration()
        {
            ToTable("Atendimentos");
            HasKey(a => a.AtendimentoId);
            Property(p => p.AtendimentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Data)
                .IsRequired();
            Property(a => a.Status)
                .HasMaxLength(15)
                .IsRequired();
            Ignore(a=>a.ValorTotal);

            
        }
    }
}