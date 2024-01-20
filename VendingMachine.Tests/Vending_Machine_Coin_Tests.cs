using FluentAssertions;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    
    public class VendingMachineCoinTests: VendingMachineBaseTest
    {
        [Test]
        public void Penny_Should_Be_Rejected_Placed_In_Coin_Return()
        {
            VendingMachine.InsertCoin(Penny);

            VendingMachine
                .GetReturnTray()
                .Count
                .Should()
                .Be(1);

            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("INSERT COIN");
        }

        [Test]
        public void Dime_Should_Be_Accepted_And_Display_And_Total_Updated()
        {
            VendingMachine.InsertCoin(Dime);
            
            VendingMachine
                .GetReturnTray()
                .Count
                .Should()
                .Be(0);

            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0.1);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("0.1");
        }

        [Test]
        public void Accept_One_Of_Each_Coin_And_Display_And_Total_Updated()
        {
            VendingMachine.InsertCoin(Dime);
            VendingMachine.InsertCoin(Nickel);
            VendingMachine.InsertCoin(Quarter);
            VendingMachine.InsertCoin(Penny);
            
            VendingMachine
                .GetReturnTray()
                .Count
                .Should()
                .Be(1);

            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0.4);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("0.4");
        }
    }
}