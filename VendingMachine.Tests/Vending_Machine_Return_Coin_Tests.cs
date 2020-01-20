using NUnit.Framework;

namespace VendingMachine.Tests
{
    /**
     * As a customer
     * I want to have my money returned
     * So that I can change my mind about buying stuff from the vending machine
    */
    
    public class Vending_Machine_Return_Coin_Tests: VendingMachineBaseTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
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