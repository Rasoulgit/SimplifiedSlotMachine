using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class SymbolsCombinicationGenerator : ISymbolCombinicationGenrator
    {
        private readonly ISymbolConfigurations _symbolConfigurations;
        private readonly Random _random = new Random();
        protected readonly List<char> _symbolList = new List<char>(100);

        public SymbolsCombinicationGenerator(ISymbolConfigurations configurations)
        {
            _symbolConfigurations = configurations ?? throw new ArgumentNullException(nameof(configurations));

            foreach (var symbol in _symbolConfigurations.Symbols)
            {
                FillSymbolListByProbability(symbol);
            }

            _symbolList = ShuffleSymbolList();

            List<char> ShuffleSymbolList()
            {
                return _symbolList.OrderBy(x => _random.Next()).ToList();
            }

            void FillSymbolListByProbability(Symbol symbol)
            {
                for (int i = 0; i < symbol.Probability; i++)
                {
                    _symbolList.Add(symbol.Character);
                }
            }
        }

        public string GetNew()
        {
            string symbolsCombination = string.Empty;

            for (int i = 0; i < _symbolConfigurations.SymbolsCombinationLength; i++)
            {
                symbolsCombination += _symbolList[_random.Next(_symbolList.Count - 1)];
            }

            return symbolsCombination;
        }
    }

}
