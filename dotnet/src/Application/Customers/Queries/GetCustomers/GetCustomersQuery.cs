using Dotland.DotCapital.WebApi.Application.Common.Mappings;
using Dotland.DotCapital.WebApi.Application.Common.Models;
using Dotland.DotCapital.WebApi.Application.Customers.DTOs;

namespace Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomers;

public record GetCustomersQuery : IRequest<GetCustomersResponse>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCustomersQueryHandler(IApplicationDbContext context, CustomerMapper mapper)
    : IRequestHandler<GetCustomersQuery, GetCustomersResponse>
{
    public async Task<GetCustomersResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = context.Contacts
            .Where(c => c.ContactService == "customer")
            .OrderByDescending(c => c.CreatedAt);

        var paginatedList = await mapper.ProjectToCustomerDto(query)
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

        return new GetCustomersResponse(
            paginatedList.Items,
            paginatedList.TotalCount,
            paginatedList.PageNumber,
            request.PageSize
        );
    }
}
