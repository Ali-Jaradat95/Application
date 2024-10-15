using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.LanguageIsoNameLookups;

namespace Application.LanguageIsoNameLookups
{
    public class LanguageIsoNameLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ILanguageIsoNameLookupRepository _languageIsoNameLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public LanguageIsoNameLookupsDataSeedContributor(ILanguageIsoNameLookupRepository languageIsoNameLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _languageIsoNameLookupRepository = languageIsoNameLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _languageIsoNameLookupRepository.InsertAsync(new LanguageIsoNameLookup
            (
                code: "ad3bda60598a4305a91d7d4fac86e04b589c3de7e1",
                name: "0b06f45188824a1ebf70710b67b337f08933c6c2d30c4ca7ab9136b432c876337df529cd74234e9381d8978",
                description: "17fd52c84ba34996a78119684967bd"
            ));

            await _languageIsoNameLookupRepository.InsertAsync(new LanguageIsoNameLookup
            (
                code: "7d1dc5fbe455",
                name: "4e027cfc96e94d4fa68b935a048ffe531a4b33100b8344d9818955d4b938ecc9ef930feb42",
                description: "3314c655eb2c4350a348d4882c8b8eaadd1d84c3aac5495bae5909cd14dfe8731186b7a306df"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}