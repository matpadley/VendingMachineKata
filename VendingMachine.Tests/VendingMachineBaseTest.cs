using VendingMachine.Coin;

namespace VendingMachine.Tests
{
    public abstract class VendingMachineBaseTest
    {
        protected CoinAttributes Nickel => new CoinAttributes(2, 21.12, 1.95);
        protected CoinAttributes Dime => new CoinAttributes(2.268, 17.91, 1.35);
        protected CoinAttributes Penny => new CoinAttributes(2.5, 19.05, 1.52);
        protected CoinAttributes Quarter => new CoinAttributes(6.25, 24.26, 1.75);
    }
}