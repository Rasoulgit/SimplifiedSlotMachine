using Bede.SimplifiedSlotMachine.Domain;
using Bede.SimplifiedSlotMachine.DomainModels;

namespace Bede.SimplifiedSlotMachine.Tests
{
    public class SymbolsCombinicationGeneratorTests
    {
        private class SymbolsCombinicationGeneratorExtended : SymbolsCombinicationGenerator
        {
            public SymbolsCombinicationGeneratorExtended(ISymbolConfigurations configurations) : base(configurations)
            {
            }

            public List<char> SymbolList => _symbolList;
        }

        private SymbolsCombinicationGeneratorExtended _symbolsCombinicationGenrator = default!;

        [SetUp]
        public void Setup()
        {
            _symbolsCombinicationGenrator = new SymbolsCombinicationGeneratorExtended(new SymbolConfigurations(
                    symbols: new List<Symbol>()
                        {
                            new Symbol('A',0.4d,45),
                            new Symbol('B',0.6d,35),
                            new Symbol('P',0.8d,15),
                            new Symbol('*',0.0d,5),
                        },
                    symbolsCombinationLength: 3,
                    symbolsCombinationCount: 4));
        }

        [Test]
        public void SymbolsCombinicationGenerator_SymbolList_FilledOutCorrectly()
        {
            //Act
            int numberOfItemsInSymbolList = _symbolsCombinicationGenrator.SymbolList.Count();
            int probabilityOfA = _symbolsCombinicationGenrator.SymbolList.Count(x => x == 'A');
            int probabilityOfB = _symbolsCombinicationGenrator.SymbolList.Count(x => x == 'B');
            int probabilityOfP = _symbolsCombinicationGenrator.SymbolList.Count(x => x == 'P');
            int probabilityOfWildCard = _symbolsCombinicationGenrator.SymbolList.Count(x => x == '*');

            //Assert
            Assert.That(numberOfItemsInSymbolList, Is.EqualTo(100));
            Assert.That(probabilityOfA, Is.EqualTo(45));
            Assert.That(probabilityOfB, Is.EqualTo(35));
            Assert.That(probabilityOfP, Is.EqualTo(15));
            Assert.That(probabilityOfWildCard, Is.EqualTo(5));
        }

        [Test]
        public void SymbolsCombinicationGenerator_GetNew_GenerateCombinationWithCorrectLength()
        {
            //Act
            string combination1 = _symbolsCombinicationGenrator.GetNew();

            //Assert
            Assert.AreEqual(combination1.Length, 3);

        }
    }
}