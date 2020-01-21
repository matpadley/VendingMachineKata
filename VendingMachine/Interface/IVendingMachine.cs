using System.Collections.Generic;
using VendingMachine.Model;

namespace VendingMachine.Interface
{
    public interface IVendingMachine
    {
        string GetDisplay();
        void InsertCoin(Coin coin);
        ICollection<Coin> GetReturnTray();
        double GetCurrentAmount();
        void ReturnCoins();
        void PickProduct(VendingProduct product);
    }
}