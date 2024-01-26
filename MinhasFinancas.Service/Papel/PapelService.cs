using MinhasFinancas.Repository.Papel;
using MinhasFinancas.Service.Core;
using MinhasFinancas.Service.Core.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhasFinancas.Service.Papel
{
    public class PapelService : BaseService, IPapelService
    {
        private readonly IPapelRepository _baseRepository;

        public PapelService(IPapelRepository baseRepository, INotificador notificador) : base(notificador)
        {
            _baseRepository = baseRepository;
        }

        public async Task Add(Infra.Models.Papel obj)
        {
            if (!ExecutarValidacao(new PapelValidation(), obj)) return;

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

        public async Task<IEnumerable<Infra.Models.Papel>> Get(Expression<Func<Infra.Models.Papel, bool>> filter = null, string includeProperties = null)
        {
            var retorno = await _baseRepository.Get(filter: filter, includeProperties: includeProperties);
            return retorno;
        }

        public async Task<Infra.Models.Papel> GetById(Guid id)
        {
            var retorno = await _baseRepository.GetById(id);
            return retorno;
        }

        public async Task Update(Infra.Models.Papel obj)
        {
            if (!ExecutarValidacao(new PapelValidation(), obj)) return;

            await _baseRepository.Update(obj);
            await _baseRepository.SaveChanges();
        }
    }
}