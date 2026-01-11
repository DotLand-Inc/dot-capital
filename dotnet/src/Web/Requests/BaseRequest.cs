using Microsoft.AspNetCore.Mvc;

namespace Dotland.DotCapital.WebApi.Web.Requests;

public abstract class BaseRequest 
{
    [FromHeader(Name = "organization-id")]
    public string? OrganizationId { get; set; }
}
