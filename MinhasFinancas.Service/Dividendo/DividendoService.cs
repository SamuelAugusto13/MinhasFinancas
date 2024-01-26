using MinhasFinancas.Repository.Dividendo;
using MinhasFinancas.Service.Core;
using MinhasFinancas.Service.Core.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Dividendo
{
    public class DividendoService : BaseService, IDividendoService
    {
        private readonly IDividendoRepository _baseRepository;

        public DividendoService(IDividendoRepository dividendoRepository, INotificador notificador) : base(notificador)
        {
            _baseRepository = dividendoRepository;
        }

        public async Task Add(Infra.Models.Dividendo obj)
        {
            if (!ExecutarValidacao(new DividendoValidation(), obj)) return;

            await _baseRepository.Add(obj);
            await _baseRepository.SaveChanges();
        }

        public async Task DeleteById(Guid id)
        {
            await _baseRepository.DeleteById(id);
            await _baseRepository.SaveChanges();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Infra.Models.Dividendo>> Get(Expression<Func<Infra.Models.Dividendo, bool>> filter = null, string includeProperties = null)
        {
            var retorno = await _baseRepository.Get(filter: filter, includeProperties: includeProperties);
            return retorno;
        }

        public async Task<Infra.Models.Dividendo> GetById(Guid id)
        {
            var retorno = await _baseRepository.GetById(id);
            return retorno;
        }

        public async Task Update(Infra.Models.Dividendo obj)
        {
            if (!ExecutarValidacao(new DividendoValidation(), obj)) return;

            await _baseRepository.Update(obj);
            await _baseRepository.SaveChanges();
        }
    }
}