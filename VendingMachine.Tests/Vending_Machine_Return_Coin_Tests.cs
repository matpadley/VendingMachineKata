using FluentAssertions;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    /**
     * As a customer
     * I want to have my money returned
     * So that I can change my mind about buying stuff from the vending machine
    */
    
    public class VendingMachineReturnCoinTests: VendingMachineBaseTest
    {
        [Test]
        public void Penny_Should_Be_Rejected_Placed_In_Coin_Return()
        {
            VendingMachine.InsertCoin(Penny);
            VendingMachine.InsertCoin(Dime);
            
            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0.1);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("0.1");
            
            VendingMachine.ReturnCoins();
            
            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("INSERT COIN");
        }
    }
}