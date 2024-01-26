using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Dividendo
{
    public interface IDividendoService : IDisposable
    {
        Task Add(Infra.Models.Dividendo obj);
        Task Update(Infra.Models.Dividendo obj);
        Task DeleteById(Guid id);
        Task<IEnumerable<Infra.Models.Dividendo>> Get(Expression<Func<Infra.Models.Dividendo, bool>> filter = null, string includeProperties = null);
        Task<Infra.Models.Dividendo> GetById(Guid id);
    }
}
