using System;
using System.Collections.Generic;
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
            Property(a => a.Data)
                .IsRequired();
            Property(a => a.Status)
                .HasMaxLength(15)
                .HasColumnType("varchar")
                .IsRequired();
            Ignore(a=>a.ValorTotal);

            
        }
    }
}