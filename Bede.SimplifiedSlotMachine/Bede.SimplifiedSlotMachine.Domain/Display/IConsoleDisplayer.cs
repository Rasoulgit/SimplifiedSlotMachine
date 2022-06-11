using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Domain
{
    public class ConsoleDisplayer : IDispalyer
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public string? Read()
        {
            return Console.ReadLine();
        }

        public void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
