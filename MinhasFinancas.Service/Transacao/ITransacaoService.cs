using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Transacao
{
    public interface ITransacaoService : IDisposable
    {
        Task Add(Infra.Models.Transacao obj);
        Task Update(Infra.Models.Transacao obj);
        Task DeleteById(Guid id);
        Task<IEnumerable<Infra.Models.Transacao>> Get(Expression<Func<Infra.Models.Transacao, bool>> filter = null, string includeProperties = null);
        Task<Infra.Models.Transacao> GetById(Guid id);
    }
}
