using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Application.MadfoatcomResponses;

namespace Application.MadfoatcomResponses
{
    public class MadfoatcomResponsesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IMadfoatcomResponseRepository _madfoatcomResponseRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public MadfoatcomResponsesDataSeedContributor(IMadfoatcomResponseRepository madfoatcomResponseRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _madfoatcomResponseRepository = madfoatcomResponseRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _madfoatcomResponseRepository.InsertAsync(new MadfoatcomResponse
            (
                billerCode: 1912363782,
                billingNo: "cb2c652543404a63a2621826217d912867ed6659b3be408d989e37a",
                billNo: "604389ad8fea48398b68c845a98308fb6b3fb49",
                dueAmt: "c60bc6a4201c44f1bf61ef5765c9e3b524d42663e86f432daea7e3cafa16e2fa8086a58f1d7543cb",
                validationCode: "bbb3c1e4bc1446389632",
                serviceType: "88b9e3f9f1034e1d90fc716dbb5f4d31f9e933749d7f45e4a95c32727f5641d424439738f",
                prepaidCat: "de8ae91bf55b41d7b6b7099c7f43cf3d13a17259cc79499da5eef7c505",
                amount: "5dc2365ddb1c41f7abcf68bf5703d9aa59963d5f354941",
                setBnkCode: 1812912234,
                acctNo: "74f7db2ad4a3",
                transferReason: "613ea601adcb4f759c14466c94ffb462a9db267da2f742b0b6b6188d9ab4259eb7c40cfd921446",
                receivingCountry: "d546c354eff94f34a3472fbba3b3836be77389a70d3145b",
                custName: "2c3f4c3e63df4fea8fd03dca27883d2db890ef01c6c84d189e8245",
                email: "47a2d5efde794a5595d612c753049b70521b5666d9b74a7499c9986338a9b0818e2574b3fbc749529f1cb3f1b9e8634819",
                phone: "7a41c4ed3e704109afd5812c9fe366f75f950e0708cf49a7973c23357220cfa32d4",
                recCount: 382634694,
                billStatus: "8bf084a7e59747a78e8dc66b359490b4b5e69484af314492a871c073dd7eb5b8eb396d8a4dab46f38e",
                dueAmount: "167b93569f6d4219906316aa22211ec88e17038857344da9b16886b54fa5a6c1a7ada03",
                issueDate: new DateTime(2006, 4, 19),
                openDate: new DateTime(2016, 10, 3),
                dueDate: new DateTime(2023, 6, 5),
                expiryDate: new DateTime(2007, 5, 25),
                closeDate: new DateTime(2018, 3, 6),
                billType: "1bfb6506f49846c98ac9e53e06a69b8554927e2377cf4c5cbd07608ea87671121043363dd5a345468ad8ad7079db245480",
                allowPart: true,
                upper: "f0224645ab2748669029394958c9606bf23c51aaea3d4dd5b800528c9610f5536ce089f92f2443a29f4941af7df0e9ea640",
                lower: "36f14dda1f3148fc9e70ca98777355b437177ac8eea2400fb1fe7cf7596f38b5829a4b4175bb481eb10cdc9bac32537522",
                billsCount: 869679596,
                jOEBPPSTrx: "d55534bc38844",
                processDate: new DateTime(2001, 10, 8),
                sTMTDate: "4a9438d907"
            ));

            await _madfoatcomResponseRepository.InsertAsync(new MadfoatcomResponse
            (
                billerCode: 1532379110,
                billingNo: "f6b281b3348d4d1c93408b7d92277d40e1c989a69c674ee5acd4f566919e91cc5",
                billNo: "1f5a0c5a7ee5447698d580bf9e7548",
                dueAmt: "8267fd071d5843e7839546f127c5061c696474ee4fc448",
                validationCode: "ba5f983b8a0d4d3c8494f09e1845fec1a42a15d",
                serviceType: "a7f2826e0172420aa188568fe4038194d4c8681b113944dbb2e5f443ed99cf199a6a8531c9a7495090f30512c95282",
                prepaidCat: "71a932bdf0a54ab5ae",
                amount: "e2e911a29c504a2c97b38",
                setBnkCode: 807953897,
                acctNo: "39e1ec",
                transferReason: "2143a7e31fc44e6aaad6d413454c7c34eee7e31f82514a0cb0390def22e80e5a9b6e503899a7438aad3e3c6d66766",
                receivingCountry: "7f0fc8e33fd04115b619",
                custName: "046c2b66161a473a82cd43b8716b56af0ec9886c55144",
                email: "8c7b2a93658d4f0d881e4e86cfad1304ae37e850031547e88bb7dc49e11dc0c26ccddb6f2f5a408eb76e0a96abe5b",
                phone: "7b3c65431e8d4081bc4d310785645f3c885ad23f41ed4ff1b82ea4345e37800b6c126c873f2445a4b309bdfc8660882c58",
                recCount: 1937462798,
                billStatus: "9a0b2f5d1ab24759ab31d9f01eaf9a16ce75ae30137a4345",
                dueAmount: "4910a10df7cd4cd0",
                issueDate: new DateTime(2018, 7, 25),
                openDate: new DateTime(2019, 7, 5),
                dueDate: new DateTime(2013, 7, 4),
                expiryDate: new DateTime(2023, 7, 23),
                closeDate: new DateTime(2015, 3, 14),
                billType: "18d926925b6b40bfb5252a0ffb0df9298eb9172994fb44f99c0a93c025c23cd3aa1fe7d7",
                allowPart: true,
                upper: "bfae29aca28c43b19b9c9ec0e95b14e9ba77f14ddbc04585ab7492336e9",
                lower: "9a947e98",
                billsCount: 1174027188,
                jOEBPPSTrx: "274fd94cb5fc4987b8e6ef80319a1bf846673956918449e9b",
                processDate: new DateTime(2014, 1, 3),
                sTMTDate: "27b229c322124a9"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}