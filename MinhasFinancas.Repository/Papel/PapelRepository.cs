using MinhasFinancas.Infra.Data;
using MinhasFinancas.Repository.Core;

namespace MinhasFinancas.Repository.Papel
{
    public class PapelRepository : Repository<Infra.Models.Papel>, IPapelRepository
    {
        public PapelRepository(AppDbContext db) : base(db)
        {
        }
    }
}