using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.MadfoatcomResponses
{
    public class MadfoatcomResponsesAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IMadfoatcomResponsesAppService _madfoatcomResponsesAppService;
        private readonly IRepository<MadfoatcomResponse, int> _madfoatcomResponseRepository;

        public MadfoatcomResponsesAppServiceTests()
        {
            _madfoatcomResponsesAppService = GetRequiredService<IMadfoatcomResponsesAppService>();
            _madfoatcomResponseRepository = GetRequiredService<IRepository<MadfoatcomResponse, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _madfoatcomResponsesAppService.GetListAsync(new GetMadfoatcomResponsesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _madfoatcomResponsesAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MadfoatcomResponseCreateDto
            {
                BillerCode = 1307177267,
                BillingNo = "9c6b963441794ecca8a2adc5783619927615ea4bd2e94c4f8b75edb21f066e",
                BillNo = "98bfafb43d5f41069f684a54d2a77053bc751792f73143a18db41d176df3619d241ec",
                DueAmt = "1c2c5f8f8184439eaa59917912fec831730ba653d14a431bb978787",
                ValidationCode = "f9a502712",
                ServiceType = "b089fd74b573478982f3ea61ab25d97b3855f93fa4774265b93c98f0545ce17",
                PrepaidCat = "ef593b1e44024c618b86a2a0c69b93ee013e9af919ce44e2bf3e131c18cce1ddd9505f7dbc104688a5f7e69e7",
                Amount = "6578e0d26e86491db0b8129dedf6d0b41729a20646df4d2a9129bc2a1cdaba053553fff57710483982f7",
                SetBnkCode = 1386643697,
                AcctNo = "07213d7b247d48ed856c2e4a719e0b254aef8c31e7524b2fb0acf14cf2377cb1feb0d3463845498386d",
                TransferReason = "bb7ee36ebf05491ab30f0fccc5073839a2b7478c22",
                ReceivingCountry = "c79c48a3de31497fae5cc9e44dbd45d0c87eafbb331d4f7c9df86863",
                CustName = "fb051329855549509d",
                Email = "9dda8f3860c54eb8af92c8d94a693c6637bfd44d8150472080329b59269ad1f4870aac4afbf14dde",
                Phone = "10d37eb348da4224847bd603951",
                RecCount = 977378428,
                BillStatus = "a00623a898db465897b90ab5008fea50d3ed24b7390941a088a812c4d2e32acee4727db23e364b0486492",
                DueAmount = "86e0a69a0c5b401",
                IssueDate = new DateTime(2023, 11, 13),
                OpenDate = new DateTime(2011, 9, 4),
                DueDate = new DateTime(2017, 9, 11),
                ExpiryDate = new DateTime(2000, 9, 20),
                CloseDate = new DateTime(2016, 5, 5),
                BillType = "46b30ef8f5ae",
                AllowPart = true,
                Upper = "9d7e1b19b5cf4a93b62285b72c6fae2c",
                Lower = "c14bc3493d31470c99a0a0f5c2baa7fe2f9b76b09266423aacf1a5411391356d802b171509ac49c983cb9ff545521",
                BillsCount = 441353281,
                JOEBPPSTrx = "1990a83da8d440e583b756e49d930c7ddd83c52238a64d87a4d4ff45b886d0e638d478baaa1",
                ProcessDate = new DateTime(2004, 5, 21),
                STMTDate = "ff569b35ddd34a579c1b219cfc306241010fab22d1bb41a593e6c4c0b36f17eb0b6ff896baa5482f847507"
            };

            // Act
            var serviceResult = await _madfoatcomResponsesAppService.CreateAsync(input);

            // Assert
            var result = await _madfoatcomResponseRepository.FindAsync(c => c.BillerCode == serviceResult.BillerCode);

            result.ShouldNotBe(null);
            result.BillerCode.ShouldBe(1307177267);
            result.BillingNo.ShouldBe("9c6b963441794ecca8a2adc5783619927615ea4bd2e94c4f8b75edb21f066e");
            result.BillNo.ShouldBe("98bfafb43d5f41069f684a54d2a77053bc751792f73143a18db41d176df3619d241ec");
            result.DueAmt.ShouldBe("1c2c5f8f8184439eaa59917912fec831730ba653d14a431bb978787");
            result.ValidationCode.ShouldBe("f9a502712");
            result.ServiceType.ShouldBe("b089fd74b573478982f3ea61ab25d97b3855f93fa4774265b93c98f0545ce17");
            result.PrepaidCat.ShouldBe("ef593b1e44024c618b86a2a0c69b93ee013e9af919ce44e2bf3e131c18cce1ddd9505f7dbc104688a5f7e69e7");
            result.Amount.ShouldBe("6578e0d26e86491db0b8129dedf6d0b41729a20646df4d2a9129bc2a1cdaba053553fff57710483982f7");
            result.SetBnkCode.ShouldBe(1386643697);
            result.AcctNo.ShouldBe("07213d7b247d48ed856c2e4a719e0b254aef8c31e7524b2fb0acf14cf2377cb1feb0d3463845498386d");
            result.TransferReason.ShouldBe("bb7ee36ebf05491ab30f0fccc5073839a2b7478c22");
            result.ReceivingCountry.ShouldBe("c79c48a3de31497fae5cc9e44dbd45d0c87eafbb331d4f7c9df86863");
            result.CustName.ShouldBe("fb051329855549509d");
            result.Email.ShouldBe("9dda8f3860c54eb8af92c8d94a693c6637bfd44d8150472080329b59269ad1f4870aac4afbf14dde");
            result.Phone.ShouldBe("10d37eb348da4224847bd603951");
            result.RecCount.ShouldBe(977378428);
            result.BillStatus.ShouldBe("a00623a898db465897b90ab5008fea50d3ed24b7390941a088a812c4d2e32acee4727db23e364b0486492");
            result.DueAmount.ShouldBe("86e0a69a0c5b401");
            result.IssueDate.ShouldBe(new DateTime(2023, 11, 13));
            result.OpenDate.ShouldBe(new DateTime(2011, 9, 4));
            result.DueDate.ShouldBe(new DateTime(2017, 9, 11));
            result.ExpiryDate.ShouldBe(new DateTime(2000, 9, 20));
            result.CloseDate.ShouldBe(new DateTime(2016, 5, 5));
            result.BillType.ShouldBe("46b30ef8f5ae");
            result.AllowPart.ShouldBe(true);
            result.Upper.ShouldBe("9d7e1b19b5cf4a93b62285b72c6fae2c");
            result.Lower.ShouldBe("c14bc3493d31470c99a0a0f5c2baa7fe2f9b76b09266423aacf1a5411391356d802b171509ac49c983cb9ff545521");
            result.BillsCount.ShouldBe(441353281);
            result.JOEBPPSTrx.ShouldBe("1990a83da8d440e583b756e49d930c7ddd83c52238a64d87a4d4ff45b886d0e638d478baaa1");
            result.ProcessDate.ShouldBe(new DateTime(2004, 5, 21));
            result.STMTDate.ShouldBe("ff569b35ddd34a579c1b219cfc306241010fab22d1bb41a593e6c4c0b36f17eb0b6ff896baa5482f847507");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MadfoatcomResponseUpdateDto()
            {
                BillerCode = 836575539,
                BillingNo = "08e817a0dc6c4aeea00b618a9f87f177daf91d0ec47c4fdb954a11bf1377398ca4fce3",
                BillNo = "1776b060cd774d7fa",
                DueAmt = "cf0bc0590d314",
                ValidationCode = "88e1ce6844ba4ddd94dbcb7b845b8d59c",
                ServiceType = "335a572d75454041ab8454696f72817e579a7844b32a4d92aa21d76d94f110af3f63ea89f26546f1bc1fa724722ca2cc6c",
                PrepaidCat = "32d8d60b91924a37a1acfeae248f0d073e8e3b6f7ec34a44ae4462f78bd649c4ec5c7d4a843d45c1a2",
                Amount = "5908f457542b4fab9df250cbf6f94a65e8c805ca55314a29958352405",
                SetBnkCode = 2075795452,
                AcctNo = "874c9ba9080c4",
                TransferReason = "cb0e49",
                ReceivingCountry = "531d914f0fa3411",
                CustName = "dde7e1c99049426186565082d8",
                Email = "9e648d7296ce42e39573b8ee08ad9e0fdc8e51ce3f414655a7988bbf7dffc8fddeca01349d424914910658590acf78eb8",
                Phone = "42a2d77794634abf947aad9d099dd558f9ad0472d6e944aa8",
                RecCount = 68591308,
                BillStatus = "35530009cab348a8afc3e1260badb758bb7e608ee3694bad9040e",
                DueAmount = "b41781681d464d818d57676bd5f3ee874a8478953f0a496f8619b77afde35c256e5c20",
                IssueDate = new DateTime(2002, 6, 3),
                OpenDate = new DateTime(2008, 5, 11),
                DueDate = new DateTime(2017, 11, 6),
                ExpiryDate = new DateTime(2004, 9, 20),
                CloseDate = new DateTime(2018, 8, 25),
                BillType = "03b530ba64f04dab86c9ab000a244eefbe2ae2d4703349a7ba76ecc8430fcc7b39",
                AllowPart = true,
                Upper = "c0332438232d4076b1cbdac13e70162c663cd8c61d0f44e7ad21",
                Lower = "6b52bb015bbb4084a8ee074c371d04233732e2f887de4f82b799",
                BillsCount = 1165795928,
                JOEBPPSTrx = "b56e9446afe04c03ac9d1698a5b98f838a59a95db90e4e38b8a564f348a790c8125df5a2821a4884a1d",
                ProcessDate = new DateTime(2006, 7, 24),
                STMTDate = "3e979ca8"
            };

            // Act
            var serviceResult = await _madfoatcomResponsesAppService.UpdateAsync(1, input);

            // Assert
            var result = await _madfoatcomResponseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BillerCode.ShouldBe(836575539);
            result.BillingNo.ShouldBe("08e817a0dc6c4aeea00b618a9f87f177daf91d0ec47c4fdb954a11bf1377398ca4fce3");
            result.BillNo.ShouldBe("1776b060cd774d7fa");
            result.DueAmt.ShouldBe("cf0bc0590d314");
            result.ValidationCode.ShouldBe("88e1ce6844ba4ddd94dbcb7b845b8d59c");
            result.ServiceType.ShouldBe("335a572d75454041ab8454696f72817e579a7844b32a4d92aa21d76d94f110af3f63ea89f26546f1bc1fa724722ca2cc6c");
            result.PrepaidCat.ShouldBe("32d8d60b91924a37a1acfeae248f0d073e8e3b6f7ec34a44ae4462f78bd649c4ec5c7d4a843d45c1a2");
            result.Amount.ShouldBe("5908f457542b4fab9df250cbf6f94a65e8c805ca55314a29958352405");
            result.SetBnkCode.ShouldBe(2075795452);
            result.AcctNo.ShouldBe("874c9ba9080c4");
            result.TransferReason.ShouldBe("cb0e49");
            result.ReceivingCountry.ShouldBe("531d914f0fa3411");
            result.CustName.ShouldBe("dde7e1c99049426186565082d8");
            result.Email.ShouldBe("9e648d7296ce42e39573b8ee08ad9e0fdc8e51ce3f414655a7988bbf7dffc8fddeca01349d424914910658590acf78eb8");
            result.Phone.ShouldBe("42a2d77794634abf947aad9d099dd558f9ad0472d6e944aa8");
            result.RecCount.ShouldBe(68591308);
            result.BillStatus.ShouldBe("35530009cab348a8afc3e1260badb758bb7e608ee3694bad9040e");
            result.DueAmount.ShouldBe("b41781681d464d818d57676bd5f3ee874a8478953f0a496f8619b77afde35c256e5c20");
            result.IssueDate.ShouldBe(new DateTime(2002, 6, 3));
            result.OpenDate.ShouldBe(new DateTime(2008, 5, 11));
            result.DueDate.ShouldBe(new DateTime(2017, 11, 6));
            result.ExpiryDate.ShouldBe(new DateTime(2004, 9, 20));
            result.CloseDate.ShouldBe(new DateTime(2018, 8, 25));
            result.BillType.ShouldBe("03b530ba64f04dab86c9ab000a244eefbe2ae2d4703349a7ba76ecc8430fcc7b39");
            result.AllowPart.ShouldBe(true);
            result.Upper.ShouldBe("c0332438232d4076b1cbdac13e70162c663cd8c61d0f44e7ad21");
            result.Lower.ShouldBe("6b52bb015bbb4084a8ee074c371d04233732e2f887de4f82b799");
            result.BillsCount.ShouldBe(1165795928);
            result.JOEBPPSTrx.ShouldBe("b56e9446afe04c03ac9d1698a5b98f838a59a95db90e4e38b8a564f348a790c8125df5a2821a4884a1d");
            result.ProcessDate.ShouldBe(new DateTime(2006, 7, 24));
            result.STMTDate.ShouldBe("3e979ca8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _madfoatcomResponsesAppService.DeleteAsync(1);

            // Assert
            var result = await _madfoatcomResponseRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}