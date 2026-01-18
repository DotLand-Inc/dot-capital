using Dotland.DotCapital.WebApi.Application.Common.Mappings;
using Dotland.DotCapital.WebApi.Application.Common.Models;
using Dotland.DotCapital.WebApi.Application.Customers.DTOs;

namespace Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomers;

public record GetCustomersQuery : IRequest<GetCustomersResponse>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCustomersQuery, GetCustomersResponse>
{
    public async Task<GetCustomersResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await context.Contacts
            .Where(c => c.ContactService == "customer")
            .OrderByDescending(c => c.CreatedAt) // Match default sort order
            .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        
        return new GetCustomersResponse(
            paginatedList.Items, 
            paginatedList.TotalCount, 
            paginatedList.PageNumber, 
            request.PageSize
        );
    }
}
