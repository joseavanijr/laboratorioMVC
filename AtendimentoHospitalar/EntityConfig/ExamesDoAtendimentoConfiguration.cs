using System;
using System.Collections.Generic;
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
            Property(ea => ea.Data)
                .IsRequired();
            Property(ea => ea.Status)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnType("varchar");
            HasRequired(ea => ea.Atendimento)
                .WithMany(a => a.ListExamesDoAtendimentos)
                .HasForeignKey(ea => ea.ExamesDoAtendimentoId);
        }
    }
}