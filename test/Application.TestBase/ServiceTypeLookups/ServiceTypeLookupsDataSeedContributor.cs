using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.ServiceTypeLookups;

namespace Application.ServiceTypeLookups
{
    public class ServiceTypeLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IServiceTypeLookupRepository _serviceTypeLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ServiceTypeLookupsDataSeedContributor(IServiceTypeLookupRepository serviceTypeLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _serviceTypeLookupRepository = serviceTypeLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _serviceTypeLookupRepository.InsertAsync(new ServiceTypeLookup
            (
                code: "dfc317e946fe4a5e870b20df9ddad04192a47fa",
                name: "88f85453b3f44a65b3cc7088ce0619f2129d7233bcd24c3ea3d400afe7ccd5839c2fa427f9c24707a220ee85b70efb5b9",
                description: "418aa340b1464535821ba697a81d72f9de7164aba2f2499e90a321aaf142180e570e2eb61ba748ecadd8cf7f"
            ));

            await _serviceTypeLookupRepository.InsertAsync(new ServiceTypeLookup
            (
                code: "8b190a7fc5cf46f58fd8d12ab886305b672312d419704b47ad214259a8939b3ba9602906a59c",
                name: "1755ff57dd3d4ad1a8a11c4d8d4af5ce8b0efe571b3a44e0b3c8984728a16ea6beddb7ef9ebd4fb8bb96",
                description: "8ca7fa168a9846ce9b51eb1a0e9164c320bfc2854dac"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}