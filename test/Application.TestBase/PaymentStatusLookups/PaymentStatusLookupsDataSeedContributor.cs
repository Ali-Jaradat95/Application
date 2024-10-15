using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.PaymentStatusLookups;

namespace Application.PaymentStatusLookups
{
    public class PaymentStatusLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPaymentStatusLookupRepository _paymentStatusLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PaymentStatusLookupsDataSeedContributor(IPaymentStatusLookupRepository paymentStatusLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _paymentStatusLookupRepository = paymentStatusLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _paymentStatusLookupRepository.InsertAsync(new PaymentStatusLookup
            (
                code: "e4ea293997dd407ba30fd895b4c8dab95e074a4dc2564e3fa9bd2819559179d",
                name: "827d46bac65342dabd1f8cdd7a7972fa9164e6092",
                description: "63ab9a9c49e14c6286c7"
            ));

            await _paymentStatusLookupRepository.InsertAsync(new PaymentStatusLookup
            (
                code: "7fb1e1428c06426f92a5772722e48898fcce4c4c3af346e4922b70bb6261b957a80323dbeb0a45f79",
                name: "df6a32bbcaf34f08a28d6b28a92c7ab4f733953aa07842",
                description: "c9095fe1e6594a8b8de85957766ec8aa4a74f422fd66480bb4cb"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}