using FluentValidation;
using NUnit.Framework;

namespace VendingMachine
{
    public class ValidateCoinTests
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

    public class CoinValidator : AbstractValidator<Coin>
    {
        // This would go to a data store or some other validation end point, hopefully for multi curreny
        public CoinValidator()
        {
            RuleFor(coin => coin).NotEqual(Coin.Penny);
        }
    }
}