using NUnit.Framework;

namespace VendingMachine.Tests
{
    public class Vending_Machine_Product_Tests: VendingMachineBaseTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Correct_Message_Displayed_When_No_Money_And_Product_Chosen()
        {
            _vendingMachine.PickProduct(Cola);
            
            Assert.AreEqual($"PRICE {Cola.MonetaryValue}", _vendingMachine.GetDisplay());
            
            Assert.AreEqual(0, _vendingMachine.GetCurrentAmount());
        }

        [Test]
        public void Correct_Message_Displayed_When_Enough_Money_And_Product_Chosen()
        {
            _vendingMachine.InsertCoin(Quarter);
            _vendingMachine.InsertCoin(Quarter);
            _vendingMachine.InsertCoin(Quarter);
            _vendingMachine.InsertCoin(Quarter);
            
            _vendingMachine.PickProduct(Cola);
            
            Assert.AreEqual($"THANK YOU", _vendingMachine.GetDisplay());
            
            Assert.AreEqual(0, _vendingMachine.GetCurrentAmount());
            
            Assert.AreEqual($"INSERT COIN", _vendingMachine.GetDisplay());
        }
    }
}