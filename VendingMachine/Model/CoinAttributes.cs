namespace VendingMachine.Model
{
    public class CoinAttributes
    {
        public double Weight { get; }
        public double Diameter { get; }
        public double Thickness { get; }

        public Enum.Coin Coin { get; private set; }
        public double MonetaryValue { get; private set; }

        public CoinAttributes(double weight, double diameter, double thickness)
        {
            Weight = weight;
            Diameter = diameter;
            Thickness = thickness;
        }
        
        public void SetCoin(Enum.Coin coin)
        {
            Coin = coin;

            MonetaryValue = Coin switch
            {
                Enum.Coin.Dime => 0.1,
                Enum.Coin.Invalid => 0,
                Enum.Coin.Nickel => 0.05,
                Enum.Coin.Penny => 0.01,
                Enum.Coin.Quarter => 0.25,
                _ => 0
            };
        }
    }
}