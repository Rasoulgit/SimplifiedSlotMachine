namespace Bede.SimplifiedSlotMachine.DomainModels
{
    public interface IDispalyer
    {
        public void Show(string message);
        public void Error(string message);
        string? Read();
    }
}
