using NUnit.Framework;
using VendingMachine.Interface;
using VendingMachine.Model;
using VendingMachine.Service;

namespace VendingMachine.Tests
{
    public abstract class VendingMachineBaseTest
    {
        protected static Coin Nickel => new(2, 21.12, 1.95);
        protected static Coin Dime => new(2.268, 17.91, 1.35);
        protected static Coin Penny => new(2.5, 19.05, 1.52);
        protected static Coin Quarter => new(6.25, 24.26, 1.75);
        protected static VendingProduct Cola => new(1, "Cola");
        
        protected IVendingMachine VendingMachine;

        private ICoinService _coinService;
        
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
            VendingMachine = new VendMachine(_coinService);
        }
    }
}