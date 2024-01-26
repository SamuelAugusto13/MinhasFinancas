using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Papel
{
    public interface IPapelService : IDisposable
    {
        Task Add(Infra.Models.Papel obj);
        Task Update(Infra.Models.Papel obj);
        Task DeleteById(Guid id);
        Task<IEnumerable<Infra.Models.Papel>> Get(Expression<Func<Infra.Models.Papel, bool>> filter = null, string includeProperties = null);
        Task<Infra.Models.Papel> GetById(Guid id);
    }
}
