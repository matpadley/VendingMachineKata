namespace VendingMachine.Coin
{
    public class CoinAttributes
    {
        public double Weight { get; }
        public double Diameter { get; }
        public double Thickness { get; }

        public Coin Coin { get; private set; }
        public double MonetaryValue { get; private set; }

        public CoinAttributes(double weight, double diameter, double thickness)
        {
            Weight = weight;
            Diameter = diameter;
            Thickness = thickness;
        }
        
        public void SetCoin(Coin coin)
        {
            Coin = coin;

            MonetaryValue = Coin switch
            {
                Coin.Dime => 0.1,
                Coin.Invalid => 0,
                Coin.Nickel => 0.05,
                Coin.Penny => 0.01,
                Coin.Quarter => 0.25,
                _ => 0
            };
        }
    }
}