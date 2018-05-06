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
            HasKey(c => c.PacienteId);
            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(20);
            Property(c => c.EnumTipoConveniado)
                .HasColumnName("tipoConveniado")
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()));
                //.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));
            Property(c => c.DataNascimento)
                .IsRequired();
            HasRequired(c => c.PlanoDeSaude)
                .WithMany(p=>p.ListPacientes)
                .HasForeignKey(p=>p.PlanoDeSaudeId);
        }
    }
}
