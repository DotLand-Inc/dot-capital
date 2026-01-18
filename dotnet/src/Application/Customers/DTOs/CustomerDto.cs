using System.Text.Json.Serialization;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

namespace Dotland.DotCapital.WebApi.Application.Customers.DTOs;

public class CustomerDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("contact_service")]
    public string? ContactService { get; set; }

    [JsonPropertyName("contact_type")]
    public string? ContactType { get; set; }

    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("opening_balance")]
    public decimal OpeningBalance { get; set; }

    [JsonPropertyName("opening_balance_at")]
    public DateTime OpeningBalanceAt { get; set; }

    [JsonPropertyName("opening_balance_exchange_rate")]
    public decimal OpeningBalanceExchangeRate { get; set; }

    [JsonPropertyName("opening_balance_branch_id")]
    public int OpeningBalanceBranchId { get; set; }

    [JsonPropertyName("salutation")]
    public string? Salutation { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("work_phone")]
    public string? WorkPhone { get; set; }

    [JsonPropertyName("personal_phone")]
    public string? PersonalPhone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("billing_address1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billing_address2")]
    public string? BillingAddress2 { get; set; }

    [JsonPropertyName("billing_address_city")]
    public string? BillingAddressCity { get; set; }

    [JsonPropertyName("billing_address_country")]
    public string? BillingAddressCountry { get; set; }

    [JsonPropertyName("billing_address_email")]
    public string? BillingAddressEmail { get; set; }

    [JsonPropertyName("billing_address_postcode")]
    public string? BillingAddressPostcode { get; set; }

    [JsonPropertyName("billing_address_phone")]
    public string? BillingAddressPhone { get; set; }

    [JsonPropertyName("billing_address_state")]
    public string? BillingAddressState { get; set; }

    [JsonPropertyName("shipping_address1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shipping_address2")]
    public string? ShippingAddress2 { get; set; }

    [JsonPropertyName("shipping_address_city")]
    public string? ShippingAddressCity { get; set; }

    [JsonPropertyName("shipping_address_country")]
    public string? ShippingAddressCountry { get; set; }

    [JsonPropertyName("shipping_address_email")]
    public string? ShippingAddressEmail { get; set; }

    [JsonPropertyName("shipping_address_postcode")]
    public string? ShippingAddressPostcode { get; set; }

    [JsonPropertyName("shipping_address_phone")]
    public string? ShippingAddressPhone { get; set; }

    [JsonPropertyName("shipping_address_state")]
    public string? ShippingAddressState { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("local_opening_balance")]
    public decimal LocalOpeningBalance { get; set; }

    [JsonPropertyName("closing_balance")]
    public decimal ClosingBalance { get; set; }

    [JsonPropertyName("contact_normal")]
    public string ContactNormal => "debit";

    [JsonPropertyName("formatted_balance")]
    public string FormattedBalance => Balance.ToString("F2");

    [JsonPropertyName("formatted_opening_balance")]
    public string FormattedOpeningBalance => OpeningBalance.ToString("F2");

    [JsonPropertyName("formatted_opening_balance_at")]
    public string FormattedOpeningBalanceAt => OpeningBalanceAt.ToString("dd/MM/yy");

    [JsonPropertyName("customer_type")]
    public string? CustomerType => ContactType;

    [JsonPropertyName("formatted_customer_type")]
    public string FormattedCustomerType => ContactType == "individual" ? "customer.type.individual" : "customer.type.business";

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, CustomerDto>()
                .ForMember(d => d.ClosingBalance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(d => d.LocalOpeningBalance, opt => opt.MapFrom(s => s.OpeningBalance * s.OpeningBalanceExchangeRate));
        }
    }
}
