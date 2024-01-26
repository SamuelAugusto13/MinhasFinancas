using MinhasFinancas.Infra.Models;
using System.Data.Entity.ModelConfiguration;

namespace MinhasFinancas.Infra.Mappings
{
    public class SegmentoConfig : EntityTypeConfiguration<Segmento>
    {
        public SegmentoConfig()
        {
            HasKey(p => p.Id);

            Property(s => s.Nome)
                .IsRequired();

            Property(s => s.Descricao)
                .HasMaxLength(5000);

            Property(s => s.Ativo)
                .IsRequired();

            HasMany(s => s.Papeis).WithMany(p => p.Segmentos);

            ToTable("TbSegmento");
        }
    }
}