using MinhasFinancas.Infra.Data;
using MinhasFinancas.Repository.Core;

namespace MinhasFinancas.Repository.Segmento
{
    public class SegmentoRepository : Repository<Infra.Models.Segmento>, ISegmentoRepository
    {
        public SegmentoRepository(AppDbContext db) : base(db)
        {
        }
    }
}