using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.EmailRecipientSendingStatusLookups;

namespace Application.EmailRecipientSendingStatusLookups
{
    public class EmailRecipientSendingStatusLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IEmailRecipientSendingStatusLookupRepository _emailRecipientSendingStatusLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public EmailRecipientSendingStatusLookupsDataSeedContributor(IEmailRecipientSendingStatusLookupRepository emailRecipientSendingStatusLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _emailRecipientSendingStatusLookupRepository = emailRecipientSendingStatusLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _emailRecipientSendingStatusLookupRepository.InsertAsync(new EmailRecipientSendingStatusLookup
            (
                code: "cd72134210e845d4a523d70ed4d3352b345bc74315ec4a489619ee8a29b79f33d5c2a4c53336496bbeebe5ff5f5d",
                name: "bb11a8754352464abf9b1097569bbe3dcf6f030ce8654e0081ea330d2adb1f37a9b82a9067444",
                description: "fe98cefaf7da4b57aaefeed50c194b7a418795ae475d4adea801e99b4fdce52998a"
            ));

            await _emailRecipientSendingStatusLookupRepository.InsertAsync(new EmailRecipientSendingStatusLookup
            (
                code: "e71787bf38514e03a64562c156573b63702a47ce9b4244c38d91550f6f41c4586518318108124c",
                name: "5be7ccbcc89c4fbd8423217253d79d83ce62dd08f4f9459aa480cc5eee7d581",
                description: "fc9cb8061c444d1fb9c61c99916ac01c80705eca3f714d3caa142f3c3fe1"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}