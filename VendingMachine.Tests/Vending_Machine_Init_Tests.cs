using Moq;
using NUnit.Framework;
using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    public class Vending_Machine_Init_Tests: VendingMachineBaseTest
    {
        private IVendingMachine _vendingMachine;
        private ICoinService _coinService;
        
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
            
            _vendingMachine = new VendMachine(_coinService);
        }

        [Test]
        public void Machine_Should_Display_Correct_Message_On_Start()
        {
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }
    }
}