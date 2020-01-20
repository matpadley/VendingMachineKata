using FluentValidation;

namespace VendingMachine.Validator
{
    public class CoinValidator : AbstractValidator<Enum.Coin>
    {
        // This would go to a data store or some other validation end point, hopefully for multi curreny
        public CoinValidator()
        {
            RuleFor(coin => coin).NotEqual(Enum.Coin.Penny);
        }
    }
}