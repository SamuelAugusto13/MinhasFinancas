using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Segmento
{
    public interface ISegmentoService : IDisposable
    {
        Task Add(Infra.Models.Segmento obj);
        Task Update(Infra.Models.Segmento obj);
        Task DeleteById(Guid id);
        Task<IEnumerable<Infra.Models.Segmento>> Get(Expression<Func<Infra.Models.Segmento, bool>> filter = null, string includeProperties = null);
        Task<Infra.Models.Segmento> GetById(Guid id);
    }
}
