using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class WinCalculator : IWinCalculator
    {
        private readonly ISymbolConfigurations _symbolConfigurations;

        public WinCalculator(ISymbolConfigurations configurations)
        {
            _symbolConfigurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        public decimal Calculate(string combination, decimal stakeAmount)
        {
            decimal winAmount = 0m;

            char[] chars = combination.ToCharArray();

            if (IsWinCombination(chars))
            {
                double coefitioent = 0;
                foreach (var character in chars)
                {
                    coefitioent += GetCoefficient(character);
                }

                winAmount = CalculateWinAmount(stakeAmount, coefitioent);
            }

            return winAmount;
        }

        private static decimal CalculateWinAmount(decimal stakeAmount, double coefitioent)
        {
            return (decimal)coefitioent * stakeAmount;
        }
        private double GetCoefficient(char character)
        {
            var symbol = _symbolConfigurations.Symbols.SingleOrDefault(x => x.Character == character);

            if (symbol == null)
            {
                throw new ApplicationException($"symbol with character {character} is not configured.");
            }

            return symbol.Coefficient;
        }

        private static bool IsWinCombination(char[] chars)
        {
            return chars.Where(x => x != SymbolConstants.Wildcard).Distinct().Count() <= 1;
        }
    }

}
