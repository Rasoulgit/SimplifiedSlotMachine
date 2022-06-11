using Bede.SimplifiedSlotMachine.Domain;
using Bede.SimplifiedSlotMachine.DomainModels;
using Microsoft.Extensions.DependencyInjection;


var serviceProvider = new ServiceCollection()
            .AddSingleton<ISymbolConfigurations>(
                new SymbolConfigurations(
                    symbols: new List<Symbol>()
                        {
                            new Symbol(SymbolConstants.A,0.4d,45),
                            new Symbol(SymbolConstants.B,0.6d,35),
                            new Symbol(SymbolConstants.P,0.8d,15),
                            new Symbol(SymbolConstants.Wildcard,0.0d,5),
                        },
                    symbolsCombinationLength: 3,
                    symbolsCombinationCount: 4))
            .AddSingleton<ISymbolCombinicationGenrator, SymbolsCombinicationGenerator>()
            .AddSingleton<IDepositHolder, DepositHolder>()
            .AddTransient<IWinCalculator, WinCalculator>()
            .AddTransient<IDispalyer, ConsoleDisplayer>()
            .AddScoped<ISimplifiedSlotMachine, SimplifiedSlotMachine>()
            .BuildServiceProvider();

try
{
    using (var scope = serviceProvider.CreateScope())
    {
        var simplifiedSlotMachine = scope.ServiceProvider.GetRequiredService<ISimplifiedSlotMachine>();

        simplifiedSlotMachine.Start();
    }

}
catch (Exception e)
{
    //log execption .....
    Console.WriteLine("There is technical issue, please contact xxx");
    Console.ReadKey();
}




