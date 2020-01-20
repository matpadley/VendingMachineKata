using FluentValidation;

namespace VendingMachine.Coin
{
    public class CoinValidator : AbstractValidator<Coin>
    {
        // This would go to a data store or some other validation end point, hopefully for multi curreny
        public CoinValidator()
        {
            RuleFor(coin => coin).NotEqual(Coin.Penny);
        }
    }
}