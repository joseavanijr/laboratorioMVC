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
            Property(c => c.Estado)
                .IsRequired();
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}