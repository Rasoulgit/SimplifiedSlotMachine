namespace Bede.SimplifiedSlotMachine.DomainModels
{
    public interface IWinCalculator
    {
        decimal Calculate(string combination, decimal stakeAmount);
    }

}
