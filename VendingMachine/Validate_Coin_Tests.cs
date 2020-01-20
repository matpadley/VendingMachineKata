using FluentValidation;
using NUnit.Framework;

namespace VendingMachine
{
    public class Validate_Coin_Tests
    {
        private IValidator _coinValidator;
        
        [SetUp]
        public void Setup()
        {
            _coinValidator = new CoinValidator();
        }

        [TestCase(Coin.Nickel, true)]
        [TestCase(Coin.Dime, true)]
        [TestCase(Coin.Quarter, true)]
        [TestCase(Coin.Penny, false)]
        public void Only_Accept_Valid_Coins(Coin coin, bool accept)
        {
            Assert.AreEqual(accept, _coinValidator.Validate(coin).IsValid);
        }

    }
}