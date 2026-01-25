using System.Text.Json.Serialization;

public class CreateCustomerDto
{
    [JsonPropertyName("customer_type")]
    public string? ContactType { get; set; }
    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }
    [JsonPropertyName("opening_balance")]
    public decimal? OpeningBalance { get; set; }
    [JsonPropertyName("opening_balance_at")]
    public string? OpeningBalanceAt { get; set; }
    [JsonPropertyName("opening_balance_exchange_rate")]
    public decimal? OpeningBalanceExchangeRate { get; set; }
    [JsonPropertyName("opening_balance_branch_id")]
    public int? OpeningBalanceBranchId { get; set; }
    [JsonPropertyName("salutation")]
    public string? Salutation { get; set; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }
    [JsonPropertyName("registration_number")]
    public string? RegistrationNumber { get; set; }
    [JsonPropertyName("taxe_number")]
    public string? TaxeNumber { get; set; }
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
    [JsonPropertyName("billing_address_1")]
    public string? BillingAddress1 { get; set; }

    [JsonPropertyName("billing_address_2")]
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

    [JsonPropertyName("shipping_address_1")]
    public string? ShippingAddress1 { get; set; }

    [JsonPropertyName("shipping_address_2")]
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
}
