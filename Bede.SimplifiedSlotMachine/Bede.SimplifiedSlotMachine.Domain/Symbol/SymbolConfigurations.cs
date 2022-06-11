using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class SymbolConfigurations : ISymbolConfigurations
    {
        private const int MinimumSymbolsCombinationLength = 1;
        private const int MinimumSymbolsCombinationCount = 1; // number of rows
        private readonly IEnumerable<Symbol> _symbols;
        private readonly int _symbolsCombinationLength;
        private readonly int _symbolsCombinationCount;
        private IEqualityComparer<Symbol> comparer = new SymbolComparer();

        public SymbolConfigurations(IEnumerable<Symbol> symbols, int symbolsCombinationLength, int symbolsCombinationCount)
        {
            if (symbols == null || !symbols.Any())
            {
                throw new ArgumentNullException(nameof(symbols));
            }

            if (AreDuplicated(symbols))
            {
                throw new ArgumentException($"{nameof(symbols)} have duplicated elements.");
            }

            _symbols = symbols;

            if (symbolsCombinationLength <= MinimumSymbolsCombinationLength) throw new ArgumentOutOfRangeException(nameof(symbolsCombinationLength));
            if (symbolsCombinationCount < MinimumSymbolsCombinationCount) throw new ArgumentOutOfRangeException(nameof(symbolsCombinationCount));

            _symbolsCombinationLength = symbolsCombinationLength;
            _symbolsCombinationCount = symbolsCombinationCount;

            bool AreDuplicated(IEnumerable<Symbol> symbols)
            {
                return symbols.Distinct(comparer).Count() != symbols.Count();
            }
        }

        public IEnumerable<Symbol> Symbols => _symbols;

        public int SymbolsCombinationLength => _symbolsCombinationLength;

        public int SymbolsCombinationCount => _symbolsCombinationCount;
    }
}