using NUnit.Framework;
using VendingMachine.Interface;
using VendingMachine.Model;
using VendingMachine.Service;

namespace VendingMachine.Tests
{
    public abstract class VendingMachineBaseTest
    {
        protected Coin Nickel => new Coin(2, 21.12, 1.95);
        protected Coin Dime => new Coin(2.268, 17.91, 1.35);
        protected Coin Penny => new Coin(2.5, 19.05, 1.52);
        protected Coin Quarter => new Coin(6.25, 24.26, 1.75);
        
        protected VendingProduct Cola => new VendingProduct(1, "Cola");
        
        protected IVendingMachine _vendingMachine;
        
        protected ICoinService _coinService;
        
        [SetUp]
        public void Setup()
        {
            _coinService = new CoinService();
            _vendingMachine = new VendMachine(_coinService);
        }
    }
}