using FluentValidation;
using Grocery.Application.Products.Commands.UpdateProductPrice;

namespace Application.Products.Commands.UpdateProductPrice
{
    public class UpdateProductPriceValidator : AbstractValidator<UpdateProductPriceCommand>
    {
        public UpdateProductPriceValidator()
        {
            // TODO: Research FluentValidation api and Builder pattern
            RuleFor(v => v.Price)
                .NotNull();
        }
    }
}