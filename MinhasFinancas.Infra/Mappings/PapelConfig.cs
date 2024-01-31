using MinhasFinancas.Infra.Models;
using System.Data.Entity.ModelConfiguration;

namespace MinhasFinancas.Infra.Mappings
{
    public class PapelConfig : EntityTypeConfiguration<Papel>
    {
        public PapelConfig()
        {
            HasKey(p => p.Id);

            Property(s => s.Codigo)
                .IsRequired()
                .HasMaxLength(10);

            Property(s => s.Nome)
                .IsRequired();

            Property(s => s.TipoPapel)
                .IsRequired();

            Property(s => s.Descricao)
                .HasMaxLength(5000);

            Property(s => s.Ativo)
                .IsRequired();

            HasMany(p => p.Segmento).WithMany(s => s.Papel);

            ToTable("TbPapel");
        }
    }
}