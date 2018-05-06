using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AtendimentoHospitalar.Models;

namespace AtendimentoHospitalar.EntityConfig
{
    public class CidadeConfiguration: EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            ToTable("Cidades");
            HasKey(c => c.CidadeId);
            Property(p => p.CidadeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Estado)
                .IsRequired();
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}