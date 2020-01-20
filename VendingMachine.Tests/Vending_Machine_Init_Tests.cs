using NUnit.Framework;
using VendingMachine.Coin;
using VendingMachine.Interface;
using ICoinService = VendingMachine.Coin.ICoinService;

namespace VendingMachine.Tests
{
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    
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