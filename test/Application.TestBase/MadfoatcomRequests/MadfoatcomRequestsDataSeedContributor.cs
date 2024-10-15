using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.MadfoatcomRequests;

namespace Application.MadfoatcomRequests
{
    public class MadfoatcomRequestsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMadfoatcomRequestRepository _madfoatcomRequestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MadfoatcomRequestsDataSeedContributor(IMadfoatcomRequestRepository madfoatcomRequestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _madfoatcomRequestRepository = madfoatcomRequestRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _madfoatcomRequestRepository.InsertAsync(new MadfoatcomRequest
            (
                billerCode: 1014751571,
                billingNo: "c6abbced7ca445c3a5659c2a9a3770f9491f93051b444098bf080df308e913bae25abfb7ef",
                billNo: "15b9c934d9024c019095fc2be678cc9c90070ea288df4120abf2aaa8bf0a558a9f624b75e2884",
                serviceType: "d54c07f1b84740108f993091d6700",
                prepaidCat: "58d20e4f6b6248148a92b36b55fec352eabb3817dd454",
                dueAmt: 701267579,
                validationCode: "36c323eda64b4910a55e5ff87ceb40bfbecb5978176c4c6f9a5188e91c232fbe291556fbc36840",
                jOEBPPSTrx: "41b68a7c8928456a9a09db3546033b7d724f2cb349be45b792e09f04b1485b7df7aefd41f7464c0c922ca5689baf9a107f",
                bankTrxId: "e53bb8359bb4493aa34c1c0c139b99d69e0a5323e1044df0a0afcfe776fa634c0ed63348bc914",
                bankCode: "6903657543f443fb98662b9a441bdf44d0d2e39cc66344588dade8901e0ad3",
                pmtStatus: "2d539532e92a4c118c7cb",
                paidAmt: 1541653387,
                feesAmt: 976585039,
                feesOnBiller: true,
                processDate: new DateTime(2013, 5, 23),
                stmtDate: new DateTime(2023, 1, 19),
                accessChannel: "e28df8b3ceb04b33bda916199d6a1cce266ef4bd",
                paymentMethod: "7ed09c0783a6466e9c1f3df06d63bf9a7533558189c3482799cf47abe1",
                paymentType: "6fa041ebcbee479f905d621ecc85c67c024",
                amount: 363787868,
                setBnkCode: 1200569159,
                acctNo: "7adebe14350542c18fd05a9dc3",
                name: "67526cda49b1460b83d66ba5660c93dca3749b3456494929b887a150ef3304f61a6",
                phone: "47cab23a2ea648d98f21367f4371eded2d21abea28474c6fb280084b1b",
                address: "75c8d1f00a9e4e5da3631dba05a94f8bf1370c69b9fe416d8f173f90a8095f9ebe20daaa9f644e419",
                email: "e07345dadcc54ca190536ccb81c4dd3a949c91bae94e4177b50e46dd4959b8d44ac9039b37f9425eb400f32427288"
            ));

            await _madfoatcomRequestRepository.InsertAsync(new MadfoatcomRequest
            (
                billerCode: 688997386,
                billingNo: "61a25ae1b66446488fb58e4f0b44700ba2dbc6cc698",
                billNo: "2c047f4ca35144eab13b9ed86a634ab37f1c76075e5743b3b22804c489db5b86e70a187762f74ab3843f91b3d8d5",
                serviceType: "b37e2ca1df9d4adf892fac81104b85c15da42d7e875d4ad7956c99946a",
                prepaidCat: "1222ff7c07d44fb8b2b4051419bf5d22e3ad788993b540c58",
                dueAmt: 1241503843,
                validationCode: "200f7595d55b44199b42671a1bcc73d17c1208a6654946f2b2ba421b57c1b8f0b6dd",
                jOEBPPSTrx: "e9872c46c4c9",
                bankTrxId: "d8a402de9ce24f718c5a1e3d52d83b32a17c5a99b",
                bankCode: "6a259ec69dd0426",
                pmtStatus: "2bf1a68446e247d8a30f51a60936b06cf3c631a945ba425cb9639447d08b6dfbe",
                paidAmt: 743126105,
                feesAmt: 84949222,
                feesOnBiller: true,
                processDate: new DateTime(2018, 1, 4),
                stmtDate: new DateTime(2003, 1, 15),
                accessChannel: "d6bbc6435c954064ac19bc87f6eb0b0f885a801257b641efab2",
                paymentMethod: "b187ec70e97046d7b53155df27548e52cbb83de3fc574ca7a19300ecc0930f0a3eeb17a1e5564e72b41d1",
                paymentType: "8877fb1e2fa54cc8a6b81459be4582d8bfec1e60a1454fbeabd025d84bb10c2",
                amount: 1138630645,
                setBnkCode: 1079068705,
                acctNo: "9211bb658afe46da9ebe24296313ed880ce3",
                name: "ac6547bc91c94b04ac96ee5a13ca0c558aa66aebe29b4a9b922fada67ebe932541194c65c",
                phone: "103058c65dee42db92501c02",
                address: "dfd4c5af93fd4d2e9ae536d1b342cb299ada9188d73543dbbc0040ba787322cf1f874",
                email: "b961995a65404a569f737120e0ac2def5ae83a9527814db88f87c8c2405da137a81"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}