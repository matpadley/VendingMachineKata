using FluentAssertions;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    public class VendingMachineProductTests: VendingMachineBaseTest
    {
        [Test]
        public void Correct_Message_Displayed_When_No_Money_And_Product_Chosen()
        {
            VendingMachine.PickProduct(Cola);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be($"PRICE {Cola.MonetaryValue}");

            VendingMachine
                .GetCurrentAmount()
                .Should()
                .Be(0);
        }

        [Test]
        public void Correct_Message_Displayed_When_Enough_Money_And_Product_Chosen()
        {
            VendingMachine.InsertCoin(Quarter);
            VendingMachine.InsertCoin(Quarter);
            VendingMachine.InsertCoin(Quarter);
            VendingMachine.InsertCoin(Quarter);
            
            VendingMachine.PickProduct(Cola);
            
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("THANK YOU");

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