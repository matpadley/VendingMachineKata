using System.Collections.Generic;
using VendingMachine.Coin;

namespace VendingMachine
{
    public interface IVendingMachine
    {
        string GetDisplay();
        void InsertCoin(CoinAttributes coinAttributes);
        ICollection<CoinAttributes> GetReturnTray();
        double GetCurrentAmount();
        void ReturnCoins();
    }
}