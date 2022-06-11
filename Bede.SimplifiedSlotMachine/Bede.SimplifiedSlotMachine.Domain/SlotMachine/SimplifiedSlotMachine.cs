using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class SimplifiedSlotMachine : ISimplifiedSlotMachine
    {
        private readonly ISymbolConfigurations _configurations;
        private readonly ISymbolCombinicationGenrator _symbolCombinicationGenrator;
        private readonly IWinCalculator _winCalculator;
        private readonly IDepositHolder _depositHolder;
        private readonly IDispalyer _displayer;

        public SimplifiedSlotMachine(ISymbolConfigurations configurations,
            ISymbolCombinicationGenrator symbolCombinicationGenrator,
            IWinCalculator winCalculator,
            IDepositHolder depositHolder,
            IDispalyer displayer)
        {
            _configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
            _symbolCombinicationGenrator = symbolCombinicationGenrator ?? throw new ArgumentNullException(nameof(symbolCombinicationGenrator));
            _winCalculator = winCalculator ?? throw new ArgumentNullException(nameof(winCalculator));
            _depositHolder = depositHolder ?? throw new ArgumentNullException(nameof(depositHolder));
            _displayer = displayer ?? throw new ArgumentNullException(nameof(displayer));
        }

        public void Start()
        {
            _displayer.Show("Game started");

            while (true)
            {
                _displayer.Show("Please Enter your deposit:");

                var depositInput = _displayer.Read();

                if (DepositValidator.TryeConvertDeposit(depositInput, out decimal depositAmount))
                {
                    _depositHolder.Deposit(depositAmount);

                    break;
                }

                _displayer.Error($"deposit {depositInput} is not valid.");
            }

            while (_depositHolder.CurrentBalance > 0)
            {
                _displayer.Show("Enter your stake:");

                var stakeInput = _displayer.Read();

                if (!DepositValidator.TryConvertStake(stakeInput, out decimal stakeAmount))
                {
                    _displayer.Error($"stake {stakeInput} is not valid.");

                    continue;
                }

                if (!DepositValidator.IsStakeSuffisient(_depositHolder.CurrentBalance, stakeAmount))
                {
                    _displayer.Error($"stake {stakeAmount} is more than current balance {_depositHolder.CurrentBalance}.");

                    continue;
                }

                
                Spin(stakeAmount);
            }

            _displayer.Show("Game finished");
        }

        private void Spin(decimal stakeAmount)
        {
            decimal winAmount = 0;

            for (int i = 0; i < _configurations.SymbolsCombinationCount; i++)
            {
                var combination = _symbolCombinicationGenrator.GetNew();

                _displayer.Show(combination);

                winAmount += _winCalculator.Calculate(combination, stakeAmount);
            }

            _depositHolder.UpdateBalance(stakeAmount, winAmount);

            _displayer.Show($"you have won {winAmount}");

            _displayer.Show($"current balance is {_depositHolder.CurrentBalance}");
        }
    }

}
