namespace Bede.SimplifiedSlotMachine.Domain
{
    public class DepositValidator 
    {
        public static bool TryeConvertDeposit(string? depositAmount, out decimal deposit)
        {
            return decimal.TryParse(depositAmount, out deposit) && deposit > 0;
        }

        public static bool TryConvertStake(string? stakeInput, out decimal stake)
        {
            return decimal.TryParse(stakeInput, out stake) && stake > 0;
        }
        public static bool IsStakeSuffisient(decimal currentBalance, decimal stake)
        {
            return currentBalance >= stake;
        }
    }
}
