using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public class CoinService : ICoinService
    {
        public Enum.CoinType GetCoin(double weight, double diameter, double thickness)
        {
            // This should have acceptable legal tolerances in here
            if (weight == 2 && diameter == 21.12 && thickness == 1.95) return Enum.CoinType.Nickel;
            
            if (weight == 2.5 && diameter == 19.05 && thickness == 1.52) return Enum.CoinType.Penny;
            
            if (weight == 6.25 && diameter == 24.26 && thickness == 1.75) return Enum.CoinType.Quarter;
            
            if (weight == 2.268 && diameter == 17.91 && thickness == 1.35) return Enum.CoinType.Dime;

            return Enum.CoinType.Invalid;
        }

        public Coin GetCoin(Coin attributes)
        {
            attributes.SetCoin(GetCoin(attributes.Weight, attributes.Diameter, attributes.Thickness));
            
            return attributes;
        }
    }
}