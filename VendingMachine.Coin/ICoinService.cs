namespace VendingMachine.Coin
{
    public interface ICoinService
    {
        Coin GetCoin(decimal weight, decimal diameter, decimal thickness);
        CoinAttributes GetCoin(CoinAttributes attributes);
    }
}