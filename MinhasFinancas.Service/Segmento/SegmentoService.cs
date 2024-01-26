using MinhasFinancas.Repository.Segmento;
using MinhasFinancas.Service.Core;
using MinhasFinancas.Service.Core.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Segmento
{
    public class SegmentoService : BaseService, ISegmentoService
    {
        private readonly ISegmentoRepository _baseRepository;

        public SegmentoService(ISegmentoRepository baseRepository, INotificador notificador) : base(notificador)
        {
            _baseRepository = baseRepository;
        }

        public async Task Add(Infra.Models.Segmento obj)
        {
            if (!ExecutarValidacao(new SegmentoValidation(), obj)) return;

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
            //_baseRepository?.Dispose();
            //_baseRepository?.Dispose();
        }

        public async Task<IEnumerable<Infra.Models.Segmento>> Get(Expression<Func<Infra.Models.Segmento, bool>> filter = null, string includeProperties = null)
        {
            var retorno = await _baseRepository.Get(filter: filter, includeProperties: includeProperties);
            return retorno;
        }

        public async Task<Infra.Models.Segmento> GetById(Guid id)
        {
            var retorno = await _baseRepository.GetById(id);
            return retorno;
        }

        public async Task Update(Infra.Models.Segmento obj)
        {
            if (!ExecutarValidacao(new SegmentoValidation(), obj)) return;

            await _baseRepository.Update(obj);
            await _baseRepository.SaveChanges();
        }
    }
}