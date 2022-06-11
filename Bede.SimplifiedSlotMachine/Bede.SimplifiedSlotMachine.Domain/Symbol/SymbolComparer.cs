using Bede.SimplifiedSlotMachine.DomainModels;
using System.Diagnostics.CodeAnalysis;


namespace Bede.SimplifiedSlotMachine.Domain
{
    public class SymbolComparer : IEqualityComparer<Symbol>
    {
        public bool Equals(Symbol? x, Symbol? y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return  x.Character == y.Character;
        }

        public int GetHashCode([DisallowNull] Symbol obj)
        {
            return obj.Character.GetHashCode();
        }
    }
}
