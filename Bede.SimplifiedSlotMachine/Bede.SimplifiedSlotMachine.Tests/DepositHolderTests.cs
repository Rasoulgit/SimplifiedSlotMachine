using Bede.SimplifiedSlotMachine.Domain;

namespace Bede.SimplifiedSlotMachine.Tests
{
    public class DepositHolderTests
    {
        private DepositHolder _depositHolder = default!;
        [SetUp]
        public void Setup()
        {
            _depositHolder = new DepositHolder();
        }

        [Test]
        public void DepositHolder_UpdateBalance_Correctly()
        {
            //Arrange

            _depositHolder.Deposit(200m);

            //Act

            _depositHolder.UpdateBalance(10m, 20m);

            //Assert

            Assert.IsTrue(_depositHolder.CurrentBalance == 210.0m);
        }
    }
}
