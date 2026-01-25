using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Application.Common.Exceptions;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

namespace Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomer;

public record GetCustomerQuery(int Id) : IRequest<CustomerDto>;

public class GetCustomerQueryHandler(IApplicationDbContext context, CustomerMapper mapper)
    : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var query = context.Contacts
            .Where(c => c.Id == request.Id && c.ContactService == "customer");

        var entity = await mapper.ProjectToCustomerDto(query)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Contact), request.Id.ToString());
        }

        return entity;
    }
}
