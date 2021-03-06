﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.EntityConfig
{
    public class PacienteConfiguration: EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            ToTable("Pacientes");
            //Se fosse chave composta
            //HasKey(c => new { c.PacienteId, c.DataNascimento});
            HasKey(p => p.PacienteId);
            //AUTO-INCREMENTO
            Property(p => p.PacienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p=> p.Nome)
                .HasMaxLength(50);
            Property(p => p.EnumTipoConveniado)
                .HasColumnName("TipoConveniado")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
                //.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));
            Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnType("date");
            //HasRequired(p => p.PlanoDeSaude)
            //    .WithMany()
            //    .HasForeignKey(p => p.PlanoDeSaudeId);
        }
    }
}
