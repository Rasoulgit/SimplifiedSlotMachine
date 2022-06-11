namespace Bede.SimplifiedSlotMachine.DomainModels
{
    public interface ISymbolConfigurations
    {
        IEnumerable<Symbol> Symbols { get;}
        int SymbolsCombinationLength { get; }
        int SymbolsCombinationCount { get; }
    }
}