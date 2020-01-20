namespace VendingMachine.Coin
{
    public class CoinService : ICoinService
    {
        public Coin GetCoin(decimal weight, decimal diameter, decimal thickness)
        {
            // This should have acceptable legal tolerances in here
            if (weight == 2 && diameter == 21.12m && thickness == 1.95m) return Coin.Nickel;
            
            if (weight == 2.5m && diameter == 19.05m && thickness == 1.52m) return Coin.Penny;
            
            if (weight == 6.25m && diameter == 24.26m && thickness == 1.75m) return Coin.Quarter;
            
            if (weight == 2.268m && diameter == 17.91m && thickness == 1.35m) return Coin.Dime;

            return Coin.Invalid;
        }

        public CoinAttributes GetCoin(CoinAttributes attributes)
        {
            attributes.SetCoin(GetCoin(attributes.Weight, attributes.Diameter, attributes.Thickness));
            
            return attributes;
        }
    }
}