using Dotland.DotCapital.WebApi.Application.Customers.DTOs;

namespace Dotland.DotCapital.WebApi.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand : IRequest<CustomerDto>
{
    public CreateCustomerDto Customer { get; init; } = null!;
}

public class CreateCustomerCommandHandler(IApplicationDbContext context, CustomerMapper mapper)
    : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.ToContact(request.Customer);

        entity.ContactService = "customer";
        entity.ContactType = request.Customer.ContactType ?? "individual"; // Default to individual if not specified

        context.Contacts.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return mapper.ToCustomerDto(entity);
    }
}
