using MinhasFinancas.Infra.Data;
using MinhasFinancas.Repository.Core;

namespace MinhasFinancas.Repository.Transacao
{
    public class TransacaoRepository : Repository<Infra.Models.Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(AppDbContext db) : base(db)
        {
        }
    }
}