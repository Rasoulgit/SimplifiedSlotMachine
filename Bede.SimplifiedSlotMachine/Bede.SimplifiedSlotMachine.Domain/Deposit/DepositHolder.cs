using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class DepositHolder : IDepositHolder
    {
        private decimal _balance = 0m;
        public decimal CurrentBalance => _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void UpdateBalance(decimal stakeAmount, decimal winAmount)
        {
            _balance = _balance - stakeAmount + winAmount;
        }
    }

}
