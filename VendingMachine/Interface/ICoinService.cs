using VendingMachine.Model;

namespace VendingMachine.Interface
{
    public interface ICoinService
    {
        Enum.Coin GetCoin(double weight, double diameter, double thickness);
        CoinAttributes GetCoin(CoinAttributes attributes);
    }
}