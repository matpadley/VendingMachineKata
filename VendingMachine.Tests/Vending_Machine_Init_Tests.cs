using FluentAssertions;
using NUnit.Framework;

namespace VendingMachine.Tests
{
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    
    public class VendingMachineInitTests: VendingMachineBaseTest
    {
        [Test]
        public void Machine_Should_Display_Correct_Message_On_Start()
        {
            VendingMachine
                .GetDisplay()
                .Should()
                .Be("INSERT COIN");
        }
    }
}