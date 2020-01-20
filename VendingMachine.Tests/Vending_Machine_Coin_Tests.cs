using NUnit.Framework;
using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    
    public class Vending_Machine_Coin_Tests: VendingMachineBaseTest
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
        public void Penny_Should_Be_Rejected_Placed_In_Coin_Return()
        {
            _vendingMachine.InsertCoin(Penny);
            
            Assert.AreEqual(1, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }

        [Test]
        public void Dime_Should_Be_Accepted_And_Display_And_Total_Updated()
        {
            _vendingMachine.InsertCoin(Dime);
            
            Assert.AreEqual(0, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0.1m, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("0.1", _vendingMachine.GetDisplay());
        }

        [Test]
        public void Accept_One_Of_Each_Coin_And_Display_And_Total_Updated()
        {
            _vendingMachine.InsertCoin(Dime);
            _vendingMachine.InsertCoin(Nickel);
            _vendingMachine.InsertCoin(Quarter);
            _vendingMachine.InsertCoin(Penny);
            
            Assert.AreEqual(1, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0.40, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("0.4", _vendingMachine.GetDisplay());
        }
    }
}