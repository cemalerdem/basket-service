using System;
using FluentValidation;
using FluentValidation.Attributes;

namespace Common.Command
{
    [Validator(typeof(UpdateItemQuantityCommandValidator))]
    public class UpdateItemQuantityCommand
    {
        public UpdateItemQuantityCommand()
        {
        }

        public Guid ItemId { get; set; }
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateItemQuantityCommandValidator : AbstractValidator<UpdateItemQuantityCommand>
    {
        public UpdateItemQuantityCommandValidator()
        {
            RuleFor(x => x.Quantity).NotEqual(0).WithMessage("Quantity can not be zero");
        }
    }
}