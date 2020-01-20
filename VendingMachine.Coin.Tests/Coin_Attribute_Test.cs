using NUnit.Framework;
using VendingMachine.Model;

namespace VendingMachine
{
    
    public class Coin_Attribute_Test
    {
        [Test]
        public void Coin_Attribute_Is_Valid_After_Construction()
        {
            var attribute = new CoinAttributes(12,13,14);
            
            Assert.AreEqual(12, attribute.Weight);
            Assert.AreEqual(13, attribute.Diameter);
            Assert.AreEqual(14, attribute.Thickness);
        }
    }
}