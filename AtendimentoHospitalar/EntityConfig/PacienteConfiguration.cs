using System;
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
            Property(p=> p.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(20);
            Property(p => p.EnumTipoConveniado)
                .HasColumnName("tipoConveniado")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
                //.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));
            Property(c => c.DataNascimento)
                .IsRequired();
            HasRequired(p => p.PlanoDeSaude)
                .WithMany(pl=>pl.ListPacientes)
                .HasForeignKey(p=>p.PlanoDeSaudeId);
        }
    }
}
