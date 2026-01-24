using FluentValidation;

namespace Dotland.DotCapital.WebApi.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(v => v.Customer)
            .NotNull();
    }
}
