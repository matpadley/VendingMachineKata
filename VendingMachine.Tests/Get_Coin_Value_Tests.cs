using NUnit.Framework;

namespace VendingMachine
{
    public class Get_Coin_Value_Tests
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
        public void Assert_Correct_Coin_Was_Entered(decimal weight, decimal diameter, decimal thickness, decimal monetaryValue)
        {
            var attributes = new CoinAttributes(weight, diameter, thickness);

            _coinService.GetCoin(attributes);
            
            Assert.AreEqual(monetaryValue, attributes.MonetaryValue);
        }
    }
}