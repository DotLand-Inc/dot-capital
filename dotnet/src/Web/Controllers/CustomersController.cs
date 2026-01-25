using Dotland.DotCapital.WebApi.Application.Common.Models;
using Dotland.DotCapital.WebApi.Application.Customers.Commands.CreateCustomer;
using Dotland.DotCapital.WebApi.Application.Customers.Commands.DeleteCustomer;
using Dotland.DotCapital.WebApi.Application.Customers.Commands.EditCustomer;
using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomer;
using Dotland.DotCapital.WebApi.Application.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Mvc;

namespace Dotland.DotCapital.WebApi.Web.Controllers;

public class CustomersController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCustomersResponse>> GetCustomers([FromQuery] GetCustomersQuery query)
    {
        return await Mediator.SendQueryAsync<GetCustomersQuery, GetCustomersResponse>(query);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        return await Mediator.SendQueryAsync<GetCustomerQuery, CustomerDto>(new GetCustomerQuery(id));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer([FromBody] CreateCustomerDto dto)
    {
        var command = new CreateCustomerCommand
        {
            Customer = dto
        };

        return await Mediator.SendCommandAsync<CreateCustomerCommand, CustomerDto>(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CustomerDto>> EditCustomer([FromRoute] int id, [FromBody] EditCustomerDto dto)
    {
        var command = new EditCustomerCommand
        {
            Id = id,
            Customer = dto
        };

        return await Mediator.SendCommandAsync<EditCustomerCommand, CustomerDto>(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await Mediator.SendCommandAsync(new DeleteCustomerCommand(id));

        return Ok();
    }
}
