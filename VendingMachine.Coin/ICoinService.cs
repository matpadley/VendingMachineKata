namespace VendingMachine.Coin
{
    public interface ICoinService
    {
        Coin GetCoin(double weight, double diameter, double thickness);
        CoinAttributes GetCoin(CoinAttributes attributes);
    }
}