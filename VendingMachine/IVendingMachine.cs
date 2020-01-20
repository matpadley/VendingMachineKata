using System.Collections.Generic;
using VendingMachine.Coin;
using VendingMachine.Tests;

namespace VendingMachine
{
    public interface IVendingMachine
    {
        string GetDisplay();
        void InsertCoin(CoinAttributes coinAttributes);
        ICollection<CoinAttributes> GetReturnTray();
        double GetCurrentAmount();
        void ReturnCoins();
        void PickProduct(VendingProduct product);
    }
}