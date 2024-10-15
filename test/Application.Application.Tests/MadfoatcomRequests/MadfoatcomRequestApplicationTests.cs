using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Application.MadfoatcomRequests
{
    public class MadfoatcomRequestsAppServiceTests : ApplicationApplicationTestBase
    {
        private readonly IMadfoatcomRequestsAppService _madfoatcomRequestsAppService;
        private readonly IRepository<MadfoatcomRequest, int> _madfoatcomRequestRepository;

        public MadfoatcomRequestsAppServiceTests()
        {
            _madfoatcomRequestsAppService = GetRequiredService<IMadfoatcomRequestsAppService>();
            _madfoatcomRequestRepository = GetRequiredService<IRepository<MadfoatcomRequest, int>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _madfoatcomRequestsAppService.GetListAsync(new GetMadfoatcomRequestsInput());

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
            var result = await _madfoatcomRequestsAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new MadfoatcomRequestCreateDto
            {
                BillerCode = 1673260192,
                BillingNo = "c07bbb416569490b97",
                BillNo = "50fd930e0f7b48ddb13247ddcb3cba02c576084bcbee4a5d8aa",
                ServiceType = "d35fa914cbac415cac9c2b4e7fb511dfa521a16bc69142a9a22874aa4ac13c2bb62226a9e8704f7f90e3b0eb0b584aa7",
                PrepaidCat = "f8f0b7f93ee5420fa6",
                DueAmt = 1492601357,
                ValidationCode = "d81050f701724afc976610882657cf1213a03884e2ec4c16bf4ac3e6",
                JOEBPPSTrx = "75bb9abf6",
                BankTrxId = "090a466a79d443f6914feab5d53a9ec8fc4062272f984e2e",
                BankCode = "187fd59bd71344458ef35c2881eb37fe5e7463f236cd4c928375885d8165d5c4e8d371440f784e35aa673253cf81b43",
                PmtStatus = "b9552faa79dd4bacb3db255155cf3c62380f6b44eb4f4919bcac98810fe3c2e6ecb76e175946441cac2010c15366",
                PaidAmt = 1062639778,
                FeesAmt = 2045665482,
                FeesOnBiller = true,
                ProcessDate = new DateTime(2015, 6, 9),
                StmtDate = new DateTime(2006, 1, 3),
                AccessChannel = "57381e45775c47b096a8f5c6f7bc22fd1b0",
                PaymentMethod = "1f36cbde17ec4d3d89b0ffa5f7f41461",
                PaymentType = "382a942546af4dac829f1bb2d38056139118",
                Amount = 1436629205,
                SetBnkCode = 1924241587,
                AcctNo = "ee218433c",
                Name = "d01695a694794bc68e2f9d36e5d7071c56fe79bb0a0243be9a39b63facaa0d4af740aafa0d5544e4ba7b47",
                Phone = "88e0de0630684de3adfae72",
                Address = "5c4613e001634a6094df5b28a08b74fd92e81b3cbbe143c6918501297f9009bd2f5f7e58a789406a85",
                Email = "06c154fed59b4e6d92fa3f9fbe503"
            };

            // Act
            var serviceResult = await _madfoatcomRequestsAppService.CreateAsync(input);

            // Assert
            var result = await _madfoatcomRequestRepository.FindAsync(c => c.BillerCode == serviceResult.BillerCode);

            result.ShouldNotBe(null);
            result.BillerCode.ShouldBe(1673260192);
            result.BillingNo.ShouldBe("c07bbb416569490b97");
            result.BillNo.ShouldBe("50fd930e0f7b48ddb13247ddcb3cba02c576084bcbee4a5d8aa");
            result.ServiceType.ShouldBe("d35fa914cbac415cac9c2b4e7fb511dfa521a16bc69142a9a22874aa4ac13c2bb62226a9e8704f7f90e3b0eb0b584aa7");
            result.PrepaidCat.ShouldBe("f8f0b7f93ee5420fa6");
            result.DueAmt.ShouldBe(1492601357);
            result.ValidationCode.ShouldBe("d81050f701724afc976610882657cf1213a03884e2ec4c16bf4ac3e6");
            result.JOEBPPSTrx.ShouldBe("75bb9abf6");
            result.BankTrxId.ShouldBe("090a466a79d443f6914feab5d53a9ec8fc4062272f984e2e");
            result.BankCode.ShouldBe("187fd59bd71344458ef35c2881eb37fe5e7463f236cd4c928375885d8165d5c4e8d371440f784e35aa673253cf81b43");
            result.PmtStatus.ShouldBe("b9552faa79dd4bacb3db255155cf3c62380f6b44eb4f4919bcac98810fe3c2e6ecb76e175946441cac2010c15366");
            result.PaidAmt.ShouldBe(1062639778);
            result.FeesAmt.ShouldBe(2045665482);
            result.FeesOnBiller.ShouldBe(true);
            result.ProcessDate.ShouldBe(new DateTime(2015, 6, 9));
            result.StmtDate.ShouldBe(new DateTime(2006, 1, 3));
            result.AccessChannel.ShouldBe("57381e45775c47b096a8f5c6f7bc22fd1b0");
            result.PaymentMethod.ShouldBe("1f36cbde17ec4d3d89b0ffa5f7f41461");
            result.PaymentType.ShouldBe("382a942546af4dac829f1bb2d38056139118");
            result.Amount.ShouldBe(1436629205);
            result.SetBnkCode.ShouldBe(1924241587);
            result.AcctNo.ShouldBe("ee218433c");
            result.Name.ShouldBe("d01695a694794bc68e2f9d36e5d7071c56fe79bb0a0243be9a39b63facaa0d4af740aafa0d5544e4ba7b47");
            result.Phone.ShouldBe("88e0de0630684de3adfae72");
            result.Address.ShouldBe("5c4613e001634a6094df5b28a08b74fd92e81b3cbbe143c6918501297f9009bd2f5f7e58a789406a85");
            result.Email.ShouldBe("06c154fed59b4e6d92fa3f9fbe503");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new MadfoatcomRequestUpdateDto()
            {
                BillerCode = 1202090809,
                BillingNo = "34692508dbfc40258e1e21932eeb510b5cf4d0659649460e936f720e20a8d38cef5a22b929db43a581c61f3c",
                BillNo = "751c3ec8e36b45fdb970e54f9b342c7c7730e2f8d82e48689691454456bf23b15e",
                ServiceType = "d210cf5",
                PrepaidCat = "8dfdaa94052842d394a147dddad5fe2a791939e6fb644f4d9448992c9d939b0903ba305358c54",
                DueAmt = 1806589455,
                ValidationCode = "48c91a410456405687f8",
                JOEBPPSTrx = "bc07440dba2a467",
                BankTrxId = "f95a7b056fc44ac09a8f92dc2abdee04d32b9c96",
                BankCode = "ad0e535c",
                PmtStatus = "f82f775fe36a45ec9676bf7eb9a1203d5b6aabe805f0478db92ea164b98da3c637f34acead244a709014f464ba73a36aa4e",
                PaidAmt = 384091729,
                FeesAmt = 918451749,
                FeesOnBiller = true,
                ProcessDate = new DateTime(2013, 6, 9),
                StmtDate = new DateTime(2020, 11, 9),
                AccessChannel = "12c9fee3de6b48faa455e6a69fb141372230269b146f4d09b3d05d46121633e0408c28a2f7794d1ebdd3",
                PaymentMethod = "0b6d899f4ac043cfa775ccd0325d6a2f42b1b58b92df4c9383f3ec6a7e195",
                PaymentType = "acd56aadb9a84140b63e0e452e112174ad06a66f0099405eb99273dd0ba9721233e3a0b517cb4",
                Amount = 1707659129,
                SetBnkCode = 1525749952,
                AcctNo = "70c20f3aa38043038b571a788ab4b7",
                Name = "df41d9e754414c3f90080e5c8d688b5e4144a78490f046ac99ee348aa1dbe535c2dbfd541abf4f28a082be81017538051e",
                Phone = "f509abca396946418e2d2c54292579480893863270614ec68fe714bb5c40fc883965d",
                Address = "40571cc572d54a02bd2a936fcc712d6fc709260ea2dc411ea69b977368fffc88487e27",
                Email = "01a18ac32f83453382e4d03e9ed0040d91d71e98bf4d4ce08d7eb07e8613ed0f"
            };

            // Act
            var serviceResult = await _madfoatcomRequestsAppService.UpdateAsync(1, input);

            // Assert
            var result = await _madfoatcomRequestRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.BillerCode.ShouldBe(1202090809);
            result.BillingNo.ShouldBe("34692508dbfc40258e1e21932eeb510b5cf4d0659649460e936f720e20a8d38cef5a22b929db43a581c61f3c");
            result.BillNo.ShouldBe("751c3ec8e36b45fdb970e54f9b342c7c7730e2f8d82e48689691454456bf23b15e");
            result.ServiceType.ShouldBe("d210cf5");
            result.PrepaidCat.ShouldBe("8dfdaa94052842d394a147dddad5fe2a791939e6fb644f4d9448992c9d939b0903ba305358c54");
            result.DueAmt.ShouldBe(1806589455);
            result.ValidationCode.ShouldBe("48c91a410456405687f8");
            result.JOEBPPSTrx.ShouldBe("bc07440dba2a467");
            result.BankTrxId.ShouldBe("f95a7b056fc44ac09a8f92dc2abdee04d32b9c96");
            result.BankCode.ShouldBe("ad0e535c");
            result.PmtStatus.ShouldBe("f82f775fe36a45ec9676bf7eb9a1203d5b6aabe805f0478db92ea164b98da3c637f34acead244a709014f464ba73a36aa4e");
            result.PaidAmt.ShouldBe(384091729);
            result.FeesAmt.ShouldBe(918451749);
            result.FeesOnBiller.ShouldBe(true);
            result.ProcessDate.ShouldBe(new DateTime(2013, 6, 9));
            result.StmtDate.ShouldBe(new DateTime(2020, 11, 9));
            result.AccessChannel.ShouldBe("12c9fee3de6b48faa455e6a69fb141372230269b146f4d09b3d05d46121633e0408c28a2f7794d1ebdd3");
            result.PaymentMethod.ShouldBe("0b6d899f4ac043cfa775ccd0325d6a2f42b1b58b92df4c9383f3ec6a7e195");
            result.PaymentType.ShouldBe("acd56aadb9a84140b63e0e452e112174ad06a66f0099405eb99273dd0ba9721233e3a0b517cb4");
            result.Amount.ShouldBe(1707659129);
            result.SetBnkCode.ShouldBe(1525749952);
            result.AcctNo.ShouldBe("70c20f3aa38043038b571a788ab4b7");
            result.Name.ShouldBe("df41d9e754414c3f90080e5c8d688b5e4144a78490f046ac99ee348aa1dbe535c2dbfd541abf4f28a082be81017538051e");
            result.Phone.ShouldBe("f509abca396946418e2d2c54292579480893863270614ec68fe714bb5c40fc883965d");
            result.Address.ShouldBe("40571cc572d54a02bd2a936fcc712d6fc709260ea2dc411ea69b977368fffc88487e27");
            result.Email.ShouldBe("01a18ac32f83453382e4d03e9ed0040d91d71e98bf4d4ce08d7eb07e8613ed0f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _madfoatcomRequestsAppService.DeleteAsync(1);

            // Assert
            var result = await _madfoatcomRequestRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}