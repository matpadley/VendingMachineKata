namespace VendingMachine.Model
{
    public class Coin
    {
        public double Weight { get; }
        public double Diameter { get; }
        public double Thickness { get; }

        public Enum.CoinType CoinType { get; private set; }
        public double MonetaryValue { get; private set; }

        public Coin(double weight, double diameter, double thickness)
        {
            Weight = weight;
            Diameter = diameter;
            Thickness = thickness;
        }
        
        public void SetCoin(Enum.CoinType coinType)
        {
            CoinType = coinType;

            MonetaryValue = CoinType switch
            {
                Enum.CoinType.Dime => 0.1,
                Enum.CoinType.Invalid => 0,
                Enum.CoinType.Nickel => 0.05,
                Enum.CoinType.Penny => 0.01,
                Enum.CoinType.Quarter => 0.25,
                _ => 0
            };
        }
    }
}