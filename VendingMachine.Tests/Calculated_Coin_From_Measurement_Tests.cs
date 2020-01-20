using System;
using NUnit.Framework;

namespace VendingMachine
{
    public class Calculated_Coin_From_Measurement_Tests
    {
        private ICoinService _coinService;
        
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
        }
        
        [TestCase(2, 21.12, 1.95, Coin.Nickel)]
        [TestCase(2.5, 19.05, 1.52, Coin.Penny)]
        [TestCase(6.25, 24.26, 1.75, Coin.Quarter)]
        [TestCase(2.268, 17.91, 1.35, Coin.Dime)]
        public void Assert_Correct_Coin_Was_Entered(decimal weight, decimal diameter, decimal thickness, Coin coin)
        {
            var attributes = new CoinAttributes(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            Assert.AreEqual(coin, attributes.Coin);
        }
    }

    public class CoinAttributes
    {
        public decimal Weight { get; }
        public decimal Diameter { get; }
        public decimal Thickness { get; }

        public Coin Coin { get; private set; }
        public double MonetaryValue { get; private set; }

        public CoinAttributes(decimal weight, decimal diameter, decimal thickness)
        {
            Weight = weight;
            Diameter = diameter;
            Thickness = thickness;
        }
        
        public void SetCoin(Coin coin)
        {
            Coin = coin;

            MonetaryValue = Coin switch
            {
                Coin.Dime => 0.1,
                Coin.Invalid => 0,
                Coin.Nickel => 0.05,
                Coin.Penny => 0.01,
                Coin.Quarter => 0.25,
                _ => 0
            };
        }
    }
}