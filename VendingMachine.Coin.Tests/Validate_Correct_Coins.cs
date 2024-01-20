using FluentAssertions;
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
    public class ValidateCorrectCoins
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
            var attributes = new Coin(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            attributes
                .MonetaryValue
                .Should()
                .Be(monetaryValue);
        }
        
        [TestCase(2, 21.12, 1.95, CoinType.Nickel)]
        [TestCase(2.5, 19.05, 1.52, CoinType.Penny)]
        [TestCase(6.25, 24.26, 1.75, CoinType.Quarter)]
        [TestCase(2.268, 17.91, 1.35, CoinType.Dime)]
        public void Assert_Correct_Coin_Was_Entered(double weight, double diameter, double thickness, CoinType coinType)
        {
            var attributes = new Coin(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            attributes
                .CoinType
                .Should()
                .Be(coinType);
        }
    }
}