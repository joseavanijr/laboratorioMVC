using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.EntityConfig
{
    public class ExamesDoAtendimentoConfiguration: EntityTypeConfiguration<ExamesDoAtendimento>
    {
        public ExamesDoAtendimentoConfiguration()
        {
            ToTable("ExamesDosAtendimentos");
            HasKey(ea => ea.ExamesDoAtendimentoId);
            Property(p => p.ExamesDoAtendimentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ea => ea.Data)
                .IsRequired();
            Property(ea => ea.Status)
                .IsRequired()
                .HasMaxLength(15);
            HasRequired(ea => ea.Atendimento)
                .WithMany(a => a.ListExamesDoAtendimentos)
                .HasForeignKey(ea => ea.AtendimentoId);
        }
    }
}