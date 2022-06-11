namespace Bede.SimplifiedSlotMachine.DomainModels
{
    public class Symbol
    {
        public Symbol(char character, double coefficient, int probability)
        {
            Character = character;
            Coefficient = coefficient;
            Probability = probability;
        }

        public char Character { get; }
        public double Coefficient { get; }
        public int Probability { get; }

    }
}
