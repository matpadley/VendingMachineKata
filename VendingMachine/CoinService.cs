namespace VendingMachine
{
    public class CoinService : ICoinService
    {
        public Coin GetCoin(decimal weight, decimal diameter, decimal thickness, int numEdges)
        {
            if (weight == 2 && diameter == 21.12m && thickness == 1.95m && numEdges == 1) return Coin.Nickel;
            
            if (weight == 2.5m && diameter == 19.05m && thickness == 1.52m && numEdges == 1) return Coin.Penny;
            
            if (weight == 6.25m && diameter == 24.26m && thickness == 1.75m && numEdges == 1) return Coin.Quarter;
            
            if (weight == 2.268m && diameter == 17.91m && thickness == 1.35m && numEdges == 1) return Coin.Dime;

            return Coin.Invalid;
        }
    }
}