using MinhasFinancas.Repository.Transacao;
using MinhasFinancas.Service.Core.Notificacao;
using MinhasFinancas.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace MinhasFinancas.Service.Transacao
{
    public class TransacaoService : BaseService, ITransacaoService
    {
        private readonly ITransacaoRepository _baseRepository;

        public TransacaoService(ITransacaoRepository baseRepository, INotificador notificador) : base(notificador)
        {
            _baseRepository = baseRepository;
        }

        public async Task Add(Infra.Models.Transacao obj)
        {
            if (!ExecutarValidacao(new TransacaoValidation(), obj)) return;

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

        public async Task<IEnumerable<Infra.Models.Transacao>> Get(Expression<Func<Infra.Models.Transacao, bool>> filter = null, string includeProperties = null)
        {
            var retorno = await _baseRepository.Get(filter: filter, includeProperties: includeProperties);
            return retorno;
        }

        public async Task<Infra.Models.Transacao> GetById(Guid id)
        {
            var retorno = await _baseRepository.GetById(id);
            return retorno;
        }

        public async Task Update(Infra.Models.Transacao obj)
        {
            if (!ExecutarValidacao(new TransacaoValidation(), obj)) return;

            await _baseRepository.Update(obj);
            await _baseRepository.SaveChanges();
        }
    }
}