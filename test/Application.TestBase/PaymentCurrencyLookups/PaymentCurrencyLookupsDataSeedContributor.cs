using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.PaymentCurrencyLookups;

namespace Application.PaymentCurrencyLookups
{
    public class PaymentCurrencyLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPaymentCurrencyLookupRepository _paymentCurrencyLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PaymentCurrencyLookupsDataSeedContributor(IPaymentCurrencyLookupRepository paymentCurrencyLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _paymentCurrencyLookupRepository = paymentCurrencyLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _paymentCurrencyLookupRepository.InsertAsync(new PaymentCurrencyLookup
            (
                code: "da77cb8021bb4c9fab8ec24e99f7089ad",
                name: "d5ff3b482e34445fa07f00ad5af0b5068209",
                description: "0b63a4f87d774f75a66a5581caf792fd6639613b5ba345748e45f0051bc37c80de1f669675054bb9a"
            ));

            await _paymentCurrencyLookupRepository.InsertAsync(new PaymentCurrencyLookup
            (
                code: "105f4e4dae25421ab6670ebbf3fc561e413f210f970a49b2a2c8349d",
                name: "2c96d59857cc4bc2ade24ef13cf9",
                description: "44f664b6ba34490a9041aa8058733f9382ea54ec1f864004ae9797e035e9f996ee8f11127f40499db58f3d4c7e"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}