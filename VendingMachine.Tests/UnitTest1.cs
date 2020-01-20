using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentValidation;
using Moq;
using NUnit.Framework;
using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    public class Vending_Machine_Init_Tests: VendingMachineBaseTest
    {
        private IVendingMachine _vendingMachine;
        private ICoinService _coinService;
        
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
            
            _vendingMachine = new VendMachine(_coinService);
        }

        [Test]
        public void Machine_Should_Display_Correct_Message_On_Start()
        {
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }

        [Test]
        public void Penny_Should_Be_Rejected_Placed_In_Coin_Return()
        {
            _vendingMachine.InsertCoin(Penny);
            
            Assert.AreEqual(1, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }

        [Test]
        public void Dime_Should_Be_Accepted_And_Display_And_Total_Updated()
        {
            _vendingMachine.InsertCoin(Dime);
            
            Assert.AreEqual(0, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0.1m, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("0.1", _vendingMachine.GetDisplay());
        }

        [Test]
        public void Accept_One_Of_Each_Coin_And_Display_And_Total_Updated()
        {
            _vendingMachine.InsertCoin(Dime);
            _vendingMachine.InsertCoin(Nickel);
            _vendingMachine.InsertCoin(Quarter);
            _vendingMachine.InsertCoin(Penny);
            
            Assert.AreEqual(1, _vendingMachine.GetReturnTray().Count);
            Assert.AreEqual(0.40, _vendingMachine.GetCurrentAmount());
            Assert.AreEqual("0.4", _vendingMachine.GetDisplay());
        }
    }

    public class VendMachine : IVendingMachine
    {
        private readonly ICoinService _coinService;
        
        private readonly IValidator _coinValidator;
        
        private ICollection<CoinAttributes> _coinReturn;
        
        private ICollection<CoinAttributes> _insertedCoins;

        private string _currentDisplay;

        public VendMachine(ICoinService coinService)
        {
            _coinValidator = new CoinValidator();
            _coinReturn = new Collection<CoinAttributes>();
            _insertedCoins = new Collection<CoinAttributes>();
            _coinService = coinService;

            _currentDisplay = "INSERT COIN";
        }
        
        public string GetDisplay()
        {
            return _currentDisplay;
        }

        public void InsertCoin(CoinAttributes coinAttributes)
        {
            _coinService.GetCoin(coinAttributes);

            if (_coinValidator.Validate(coinAttributes.Coin).IsValid)
            {
                _insertedCoins.Add(coinAttributes);

                _currentDisplay = GetCurrentAmount().ToString();
            }
            else
            {
                _coinReturn.Add(coinAttributes);
            }
        }

        public ICollection<CoinAttributes> GetReturnTray() => _coinReturn;
        
        public double GetCurrentAmount() => _insertedCoins.Sum(coin => coin.MonetaryValue);
    }

    interface IVendingMachine
    {
        string GetDisplay();
        void InsertCoin(CoinAttributes coinAttributes);
        ICollection<CoinAttributes> GetReturnTray();
        double GetCurrentAmount();
    }
}