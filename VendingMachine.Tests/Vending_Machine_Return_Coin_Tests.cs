using Moq;
using NUnit.Framework;
using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    public class Vending_Machine_Return_Coin_Tests: VendingMachineBaseTest
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
            _vendingMachine.InsertCoin(Dime);
            
            Assert.AreEqual(0.1m, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("0.1", _vendingMachine.GetDisplay());
            
            _vendingMachine.ReturnCoins();
            
            Assert.AreEqual(0, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }
    }
}