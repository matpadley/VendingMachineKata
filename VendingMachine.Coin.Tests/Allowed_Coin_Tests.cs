using FluentValidation;
using NUnit.Framework;
using VendingMachine.Coin;

namespace VendingMachine
{    
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    public class Allowed_Coin_Tests
    {
        private IValidator _coinValidator;
        
        [SetUp]
        public void Setup()
        {
            _coinValidator = new CoinValidator();
        }

        [TestCase(Coin.Coin.Nickel, true)]
        [TestCase(Coin.Coin.Dime, true)]
        [TestCase(Coin.Coin.Quarter, true)]
        [TestCase(Coin.Coin.Penny, false)]
        public void Only_Accept_Valid_Coins(Coin.Coin coin, bool accept)
        {
            Assert.AreEqual(accept, _coinValidator.Validate(coin).IsValid);
        }

    }
}