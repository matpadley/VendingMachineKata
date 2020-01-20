namespace VendingMachine
{
    public interface ICoinService
    {
        Coin GetCoin(decimal weight, decimal diameter, decimal thickness, int numEdges);
    }
}