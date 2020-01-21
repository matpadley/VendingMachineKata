using FluentValidation;
using NUnit.Framework;
using VendingMachine.Enum;
using VendingMachine.Validator;

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

        [TestCase(CoinType.Nickel, true)]
        [TestCase(CoinType.Dime, true)]
        [TestCase(CoinType.Quarter, true)]
        [TestCase(CoinType.Penny, false)]
        public void Only_Accept_Valid_Coins(CoinType coinType, bool accept)
        {
            Assert.AreEqual(accept, _coinValidator.Validate(coinType).IsValid);
        }

    }
}