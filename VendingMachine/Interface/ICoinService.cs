using VendingMachine.Model;

namespace VendingMachine.Interface
{
    public interface ICoinService
    {
        Enum.CoinType GetCoin(double weight, double diameter, double thickness);
        Coin GetCoin(Coin attributes);
    }
}