using FluentAssertions;
using NUnit.Framework;
using VendingMachine.Model;

namespace VendingMachine
{
    
    public class CoinAttributeTest
    {
        [Test]
        public void Coin_Attribute_Is_Valid_After_Construction()
        {
            var attribute = new Coin(12,13,14);
            
            attribute
                .Weight
                .Should()
                .Be(12);
            
            attribute
                .Diameter
                .Should()
                .Be(13);
            
            attribute
                .Thickness
                .Should()
                .Be(14);
        }
    }
}