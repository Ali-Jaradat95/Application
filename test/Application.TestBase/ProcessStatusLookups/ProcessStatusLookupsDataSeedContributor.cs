using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.ProcessStatusLookups;

namespace Application.ProcessStatusLookups
{
    public class ProcessStatusLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IProcessStatusLookupRepository _processStatusLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ProcessStatusLookupsDataSeedContributor(IProcessStatusLookupRepository processStatusLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _processStatusLookupRepository = processStatusLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _processStatusLookupRepository.InsertAsync(new ProcessStatusLookup
            (
                code: "05555adf786f4665aba14ae555058f2a80a70e927bbe41968a186064ec58660a1678e6ccea4c48d1b38",
                name: "959237",
                description: "f8cf0985771"
            ));

            await _processStatusLookupRepository.InsertAsync(new ProcessStatusLookup
            (
                code: "0b94dc3acf",
                name: "c9e729f412da4088964c0379b2b533bcc5577cb4b4764066a985d965a78288244984690437404aae918805447b34b618519",
                description: "87a906e271a640ababde8aed7af04d49833e9844674f461b95dcc15311a8251336b1a18f7a224033b298d4"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}