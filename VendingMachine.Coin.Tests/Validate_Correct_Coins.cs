using NUnit.Framework;
using VendingMachine.Enum;
using VendingMachine.Interface;
using VendingMachine.Model;
using VendingMachine.Service;

namespace VendingMachine
{    
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    public class Validate_Correct_Coins
    {
        private ICoinService _coinService;
        
        [SetUp]
        public void SetUp()
        {
            _coinService = new CoinService();
        }
        
        [TestCase(2, 21.12, 1.95, 0.05)]
        [TestCase(2.5, 19.05, 1.52, 0.01)]
        [TestCase(6.25, 24.26, 1.75, 0.25)]
        [TestCase(2.268, 17.91, 1.35, 0.1)]
        public void Assert_Correct_Coin_Was_Entered(double weight, double diameter, double thickness, double monetaryValue)
        {
            var attributes = new CoinAttributes(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            Assert.AreEqual(monetaryValue, attributes.MonetaryValue);
        }
        
        [TestCase(2, 21.12, 1.95, Coin.Nickel)]
        [TestCase(2.5, 19.05, 1.52, Coin.Penny)]
        [TestCase(6.25, 24.26, 1.75, Coin.Quarter)]
        [TestCase(2.268, 17.91, 1.35, Coin.Dime)]
        public void Assert_Correct_Coin_Was_Entered(double weight, double diameter, double thickness, Coin coin)
        {
            var attributes = new CoinAttributes(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            Assert.AreEqual(coin, attributes.Coin);
        }
    }
}