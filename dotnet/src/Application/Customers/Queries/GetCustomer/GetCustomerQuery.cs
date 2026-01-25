using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Application.Common.Exceptions;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

namespace Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomer;

public record GetCustomerQuery(int Id) : IQuery<CustomerDto>;

public class GetCustomerQueryHandler(IApplicationDbContext context, CustomerMapper mapper)
    : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    public async Task<CustomerDto> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
    {
        var dbQuery = context.Contacts
            .Where(c => c.Id == query.Id && c.ContactService == "customer");

        var entity = await mapper.ProjectToCustomerDto(dbQuery)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Contact), query.Id.ToString());
        }

        return entity;
    }
}
