using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using FluentValidation;
using VendingMachine.Coin;

namespace VendingMachine
{
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

                _currentDisplay = GetCurrentAmount().ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                _coinReturn.Add(coinAttributes);
            }
        }

        public ICollection<CoinAttributes> GetReturnTray() => _coinReturn;
        
        public double GetCurrentAmount() => _insertedCoins.Sum(coin => coin.MonetaryValue);
        public void ReturnCoins()
        {
            _insertedCoins.Clear();
            _currentDisplay = "INSERT COIN";
        }
    }
}