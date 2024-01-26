using MinhasFinancas.Infra.Models;
using System.Data.Entity.ModelConfiguration;

namespace MinhasFinancas.Infra.Mappings
{
    public class TransacaoConfig : EntityTypeConfiguration<Transacao>
    {
        public TransacaoConfig()
        {
            HasKey(t => t.Id);

            Property(t => t.ValorUnt)
                .IsRequired();

            Property(t => t.TipoTransacao)
                .IsRequired();

            Property(t => t.Quantidade)
                .IsRequired();

            Property(t => t.Descricao)
                .HasMaxLength(5000); 

            Property(f => f.Ativo)
                .IsRequired();

            HasRequired(t => t.Papel)
                .WithMany(p => p.Transacoes)
                .HasForeignKey(t => t.PapelId);

            ToTable("TbTransacao");
        }
    }
}