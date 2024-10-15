using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.MessageEncodingLookups;

namespace Application.MessageEncodingLookups
{
    public class MessageEncodingLookupsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMessageEncodingLookupRepository _messageEncodingLookupRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MessageEncodingLookupsDataSeedContributor(IMessageEncodingLookupRepository messageEncodingLookupRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _messageEncodingLookupRepository = messageEncodingLookupRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _messageEncodingLookupRepository.InsertAsync(new MessageEncodingLookup
            (
                code: "82e3004a13f94f5fb380909db3c495e9ccb920",
                name: "4d84939f112d428893ee9e665c48b05bafadccbaccb74c6b9a92e1bfa499b7adbc73fdd66ec642b5",
                description: "a76562966b49444f9f0d1412aafdfce5565d0d34b9574fcba4dfc8e5a16db2d89b5ca6e"
            ));

            await _messageEncodingLookupRepository.InsertAsync(new MessageEncodingLookup
            (
                code: "69ee83",
                name: "3babb639fbbf46d7b7",
                description: "7901e1af2e34455881fc900340cd30d0efaddf4f38fa4933b77d91a"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}