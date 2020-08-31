using System;
using Common.BaseException;
using FluentValidation;
using FluentValidation.Attributes;

namespace Common.Command
{   
    [Validator(typeof(AddItemToBasketCommandValidator))]
    public class AddItemToBasketCommand
    {
        public AddItemToBasketCommand()
        {
            
        }
        public Guid ItemId { get; set; }
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddItemToBasketCommandValidator : AbstractValidator<AddItemToBasketCommand>
    {
        public AddItemToBasketCommandValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(ErrorMessageConstants.InvalidQuantity);
        }
    }
}