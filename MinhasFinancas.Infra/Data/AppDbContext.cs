using MinhasFinancas.Infra.Models;
using MinhasFinancas.Infra.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MinhasFinancas.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MinhasFinancasDB")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<Papel>().ToTable("TbPapel");
            //modelBuilder.Entity<Transacao>().ToTable("TbTransacao");
            //modelBuilder.Entity<Dividendo>().ToTable("TbDividendo");
            //modelBuilder.Entity<Segmento>().ToTable("TbSegmento");

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar").HasMaxLength(100));

            modelBuilder.Configurations.Add(new PapelConfig());
            modelBuilder.Configurations.Add(new TransacaoConfig());
            modelBuilder.Configurations.Add(new DividendosConfig());
            modelBuilder.Configurations.Add(new SegmentoConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Papel> Papels { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        public DbSet<Dividendo> Dividendos { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
    }
}