using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.PaymentMethodLookups;

namespace Application.PaymentMethodLookups
{
    public class PaymentMethodLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPaymentMethodLookupRepository _paymentMethodLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PaymentMethodLookupsDataSeedContributor(IPaymentMethodLookupRepository paymentMethodLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _paymentMethodLookupRepository = paymentMethodLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _paymentMethodLookupRepository.InsertAsync(new PaymentMethodLookup
            (
                code: "e3e6ecffd02c455d9984ee9bca6f2824c90c45c3ad114f9a8029cead201a",
                name: "03d57166e8ed4dc99bf755e6d1076001a0123f5767734ce69c5ff73a29262eebcd877",
                description: "fb22c4752386414f824334eaea557df840b3ed4867054eada4c025974562b62f6973c66373e4485d93c3c29fbca"
            ));

            await _paymentMethodLookupRepository.InsertAsync(new PaymentMethodLookup
            (
                code: "92cbeb5e30314ed09c7dd3b46cb113f83264320b4cda4d4",
                name: "2bc5cd14916a4455a",
                description: "cac0479496e04a83a6a4feeddcb8634d7b15"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}