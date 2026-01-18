namespace Dotland.DotCapital.WebApi.Application.Customers.DTOs;

public class CreateCustomerDto
{
    public string? ContactType { get; set; }
    public string? CurrencyCode { get; set; }
    public decimal OpeningBalance { get; set; }
    public DateTime OpeningBalanceAt { get; set; }
    public decimal OpeningBalanceExchangeRate { get; set; }
    public int OpeningBalanceBranchId { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CompanyName { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public string? WorkPhone { get; set; }
    public string? PersonalPhone { get; set; }
    public string? Website { get; set; }
    public string? BillingAddress1 { get; set; }
    public string? BillingAddress2 { get; set; }
    public string? BillingAddressCity { get; set; }
    public string? BillingAddressCountry { get; set; }
    public string? BillingAddressEmail { get; set; }
    public string? BillingAddressPostcode { get; set; }
    public string? BillingAddressPhone { get; set; }
    public string? BillingAddressState { get; set; }
    public string? ShippingAddress1 { get; set; }
    public string? ShippingAddress2 { get; set; }
    public string? ShippingAddressCity { get; set; }
    public string? ShippingAddressCountry { get; set; }
    public string? ShippingAddressEmail { get; set; }
    public string? ShippingAddressPostcode { get; set; }
    public string? ShippingAddressPhone { get; set; }
    public string? ShippingAddressState { get; set; }
    public string? Note { get; set; }
}
