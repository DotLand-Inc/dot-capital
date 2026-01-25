using Dotland.DotCapital.WebApi.Application.Common.Exceptions;
using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

namespace Dotland.DotCapital.WebApi.Application.Customers.Commands.EditCustomer;

public record EditCustomerCommand : IRequest<CustomerDto>
{
    public int Id { get; init; }
    public EditCustomerDto Customer { get; init; } = null!;
}

public class EditCustomerCommandHandler(IApplicationDbContext context, CustomerMapper mapper)
    : IRequestHandler<EditCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Contacts
            .FindAsync([request.Id], cancellationToken);

        if (entity == null || entity.ContactService != "customer")
        {
            throw new NotFoundException(nameof(Contact), request.Id.ToString());
        }

        mapper.UpdateContact(request.Customer, entity);

        await context.SaveChangesAsync(cancellationToken);

        return mapper.ToCustomerDto(entity);
    }
}
