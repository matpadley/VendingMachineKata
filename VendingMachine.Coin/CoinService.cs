namespace VendingMachine.Coin
{
    public class CoinService : ICoinService
    {
        public Coin GetCoin(double weight, double diameter, double thickness)
        {
            // This should have acceptable legal tolerances in here
            if (weight == 2 && diameter == 21.12 && thickness == 1.95) return Coin.Nickel;
            
            if (weight == 2.5 && diameter == 19.05 && thickness == 1.52) return Coin.Penny;
            
            if (weight == 6.25 && diameter == 24.26 && thickness == 1.75) return Coin.Quarter;
            
            if (weight == 2.268 && diameter == 17.91 && thickness == 1.35) return Coin.Dime;

            return Coin.Invalid;
        }

        public CoinAttributes GetCoin(CoinAttributes attributes)
        {
            attributes.SetCoin(GetCoin(attributes.Weight, attributes.Diameter, attributes.Thickness));
            
            return attributes;
        }
    }
}