namespace Bede.SimplifiedSlotMachine.DomainModels
{
    public interface IDepositHolder
    {
        decimal CurrentBalance { get; }
        void UpdateBalance(decimal stakeamount, decimal winAmount);
        void Deposit(decimal amount);
    }
}
