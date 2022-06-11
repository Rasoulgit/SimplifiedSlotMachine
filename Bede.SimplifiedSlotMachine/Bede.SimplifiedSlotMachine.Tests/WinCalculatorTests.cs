using Bede.SimplifiedSlotMachine.Domain;
using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Tests
{
    public class WinCalculatorTests
    {
        private WinCalculator _winCalculator = default!;

        [SetUp]
        public void Setup()
        {
            _winCalculator = new WinCalculator(new SymbolConfigurations(
                    symbols: new List<Symbol>()
                        {
                            new Symbol('A',0.4d,45),
                            new Symbol('B',0.6d,35),
                            new Symbol('P',0.8d,15),
                            new Symbol('*',0.0d,5),
                        },
                    symbolsCombinationLength: 3,
                    symbolsCombinationCount: 1));
        }

        [Test]
        public void WinCalculator_Caclculate_Correctly()
        {
         
            //Arrange

            decimal stakeAmount = 10m;

            //Act

           var win1 = _winCalculator.Calculate("*P*", stakeAmount);
           var win2 = _winCalculator.Calculate("AAA", stakeAmount);
           var win3 = _winCalculator.Calculate("BBB", stakeAmount);
           var win4 = _winCalculator.Calculate("PPP", stakeAmount);
           var win5 = _winCalculator.Calculate("ABP", stakeAmount);
           var win6 = _winCalculator.Calculate("*AB", stakeAmount);

            //Assert

            Assert.That(win1, Is.EqualTo(8.0m));
            Assert.That(win2, Is.EqualTo(12.0m));
            Assert.That(win3, Is.EqualTo(18.0m)); //B B B (0.6 + 0.6 + 0.6)*10 = is 18 and not 16 (wrong calculation in req)
            Assert.That(win4, Is.EqualTo(24.0m));
            Assert.That(win5, Is.EqualTo(0.0m));
            Assert.That(win6, Is.EqualTo(0.0m));
        }
    }
}
