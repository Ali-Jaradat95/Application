using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.OperationTypeLookups;

namespace Application.OperationTypeLookups
{
    public class OperationTypeLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IOperationTypeLookupRepository _operationTypeLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OperationTypeLookupsDataSeedContributor(IOperationTypeLookupRepository operationTypeLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _operationTypeLookupRepository = operationTypeLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _operationTypeLookupRepository.InsertAsync(new OperationTypeLookup
            (
                code: "7f998845b63f4480b4e5f611e68",
                name: "2e684eb5da124faeb5087267928f6d669a7a3a8e4603448ebf280d6df58e60d2",
                description: "8e3d3962edc64062ba8cf2d24c74d78ff62"
            ));

            await _operationTypeLookupRepository.InsertAsync(new OperationTypeLookup
            (
                code: "323a069a040f4b18b069cceb192a8a0e",
                name: "b9b584890d5741bfb53c8c581e5ab9f0fcb3900edd994837bf5961d7cb4a609aa467cca7b3e1430ebf73412e8085d6b8f",
                description: "02637ba1df2"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}