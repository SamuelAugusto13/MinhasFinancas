using MinhasFinancas.Infra.Data;
using MinhasFinancas.Repository.Core;

namespace MinhasFinancas.Repository.Dividendo
{
    public class DividendoRepository : Repository<Infra.Models.Dividendo>, IDividendoRepository
    {
        public DividendoRepository(AppDbContext db) : base(db) 
        {
        }
    }
}