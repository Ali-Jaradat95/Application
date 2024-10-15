using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.PaymentSourceLookups;

namespace Application.PaymentSourceLookups
{
    public class PaymentSourceLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPaymentSourceLookupRepository _paymentSourceLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PaymentSourceLookupsDataSeedContributor(IPaymentSourceLookupRepository paymentSourceLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _paymentSourceLookupRepository = paymentSourceLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _paymentSourceLookupRepository.InsertAsync(new PaymentSourceLookup
            (
                code: "af733c8f507944dfa2126312a9f3d2ad306ea2fed40d447a94d37926ffbeb69c8d38a32038b043ed9c6f5fb59ff",
                name: "456268aeed9544519ce94907460df6474a50023b1c4142d7b00826e7733960a184a43cfcaf6a4513a52240e250cd112",
                description: "4086458d156342e680e8013ddc89de17af32b185"
            ));

            await _paymentSourceLookupRepository.InsertAsync(new PaymentSourceLookup
            (
                code: "3e872e6762c74f70b56b7f31ef2edd7813d57f8be45b458e83213251bd11e57d2b6c3eaae4da4d",
                name: "1b02a1ed58f142a19f14ace605f06c932bef79ab23474",
                description: "1e899a2a4a5c4b93adee7ea2ae5fafeb4108db82537a465b88"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}