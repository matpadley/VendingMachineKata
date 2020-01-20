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
        
        [TestCase(2, 21.12, 1.95, 1, Coin.Nickel)]
        [TestCase(2.5, 19.05, 1.52, 1, Coin.Penny)]
        [TestCase(6.25, 24.26, 1.75, 1, Coin.Quarter)]
        [TestCase(2.268, 17.91, 1.35, 1, Coin.Dime)]
        public void Assert_Correct_Coin_Was_Entered(decimal weight, decimal diameter, decimal thickness, int numEdges, Coin coin)
        {
            Assert.AreEqual(coin, _coinService.GetCoin(weight, diameter, thickness,numEdges));
        }
    }
}