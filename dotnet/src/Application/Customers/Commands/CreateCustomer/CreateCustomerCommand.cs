using Dotland.DotCapital.WebApi.Application.Customers.DTOs;

namespace Dotland.DotCapital.WebApi.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand : ICommand<CustomerDto>
{
    public CreateCustomerDto Customer { get; init; } = null!;
}

public class CreateCustomerCommandHandler(IApplicationDbContext context, CustomerMapper mapper)
    : ICommandHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var entity = mapper.ToContact(command.Customer);

        entity.ContactService = "customer";
        entity.ContactType = command.Customer.ContactType ?? "individual"; // Default to individual if not specified

        context.Contacts.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return mapper.ToCustomerDto(entity);
    }
}
