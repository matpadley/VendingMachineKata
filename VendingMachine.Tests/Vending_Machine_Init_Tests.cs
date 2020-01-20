using NUnit.Framework;
using VendingMachine.Interface;
using VendingMachine.Service;

namespace VendingMachine.Tests
{
    /*
     * As a vendor
     * I want a vending machine that accepts coins
     * So that I can collect money from the customer
     */
    
    public class Vending_Machine_Init_Tests: VendingMachineBaseTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Machine_Should_Display_Correct_Message_On_Start()
        {
            Assert.AreEqual("INSERT COIN", _vendingMachine.GetDisplay());
        }
    }
}