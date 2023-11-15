using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using FluentValidation;
using VendingMachine.Interface;
using VendingMachine.Model;
using CoinValidator = VendingMachine.Validator.CoinValidator;
using ICoinService = VendingMachine.Interface.ICoinService;

namespace VendingMachine
{
    public class VendMachine : IVendingMachine
    {
        private readonly string test;
        
        private readonly ICoinService _coinService;
        
        private readonly IValidator _coinValidator;
        
        private readonly ICollection<Coin> _coinReturn;
        
        private readonly ICollection<Coin> _insertedCoins;

        private string _currentDisplay;

        private bool _vendProduct = false;

        public VendMachine(ICoinService coinService)
        {
            _coinValidator = new CoinValidator();
            _coinReturn = new Collection<Coin>();
            _insertedCoins = new Collection<Coin>();
            _coinService = coinService;

            _currentDisplay = "INSERT COIN";
        }
        
        public string GetDisplay()
        {
            if (_currentDisplay == "THANK YOU" && !_vendProduct)
            {
                _vendProduct = true;
                return _currentDisplay;
            }

            if (!_vendProduct) return _currentDisplay;
            
            _currentDisplay = "INSERT COIN";
            _vendProduct = false;

            return _currentDisplay;
        }

        public void InsertCoin(Coin coin)
        {
            _coinService.GetCoin(coin);

            if (_coinValidator.Validate(coin.CoinType).IsValid)
            {
                _insertedCoins.Add(coin);

                _currentDisplay = GetCurrentAmount().ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                _coinReturn.Add(coin);
            }
        }

        public ICollection<Coin> GetReturnTray() => _coinReturn;
        
        public double GetCurrentAmount() => _insertedCoins.Sum(coin => coin.MonetaryValue);
        public void ReturnCoins()
        {
            _insertedCoins.Clear();
            _currentDisplay = "INSERT COIN";
        }

        public void PickProduct(VendingProduct product)
        {
            if (product.MonetaryValue > GetCurrentAmount())
            {
                _currentDisplay =$"PRICE {product.MonetaryValue}";
            }
            else
            {
                _insertedCoins.Clear();
                _currentDisplay = "THANK YOU";
            }
        }
    }
}
