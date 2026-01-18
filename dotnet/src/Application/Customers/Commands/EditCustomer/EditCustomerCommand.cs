using Dotland.DotCapital.WebApi.Application.Common.Exceptions;
using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

namespace Dotland.DotCapital.WebApi.Application.Customers.Commands.EditCustomer;

public record EditCustomerCommand : IRequest<CustomerDto>
{
    public int Id { get; init; }
    public EditCustomerDto Customer { get; init; } = null!;
}

public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, CustomerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EditCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null || entity.ContactService != "customer")
        {
            throw new NotFoundException(nameof(Contact), request.Id.ToString());
        }

        _mapper.Map(request.Customer, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(entity);
    }
}
