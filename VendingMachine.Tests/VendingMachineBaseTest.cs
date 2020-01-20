using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    public abstract class VendingMachineBaseTest
    {
        protected CoinAttributes Nickel => new CoinAttributes(2, 21.12m, 1.95m);
        protected CoinAttributes Dime => new CoinAttributes(2.268m, 17.91m, 1.35m);
        protected CoinAttributes Penny => new CoinAttributes(2.5m, 19.05m, 1.52m);
        protected CoinAttributes Quarter => new CoinAttributes(6.25m, 24.26m, 1.75m);
    }
}