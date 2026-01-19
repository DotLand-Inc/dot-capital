using System.ComponentModel.DataAnnotations.Schema;

namespace Dotland.DotCapital.WebApi.Domain.Entities.Tenant;

[Table("CONTACTS")]
public class Contact : BaseEntity
{
    [Column("CONTACT_SERVICE")]
    public string? ContactService { get; set; }

    [Column("CONTACT_TYPE")]
    public string? ContactType { get; set; }

    [Column("BALANCE")]
    public decimal? Balance { get; set; }

    [Column("CURRENCY_CODE")]
    public string? CurrencyCode { get; set; }

    [Column("OPENING_BALANCE")]
    public decimal? OpeningBalance { get; set; }

    [Column("OPENING_BALANCE_AT")]
    public DateTime? OpeningBalanceAt { get; set; }

    [Column("OPENING_BALANCE_EXCHANGE_RATE")]
    public decimal? OpeningBalanceExchangeRate { get; set; }

    [Column("OPENING_BALANCE_BRANCH_ID")]
    public int? OpeningBalanceBranchId { get; set; }

    [Column("SALUTATION")]
    public string? Salutation { get; set; }

    [Column("FIRST_NAME")]
    public string? FirstName { get; set; }

    [Column("LAST_NAME")]
    public string? LastName { get; set; }

    [Column("COMPANY_NAME")]
    public string? CompanyName { get; set; }

    [Column("REGISTRATION_NUMBER")]
    public string? RegistrationNumber { get; set; }

    [Column("TAX_NUMBER")]
    public string? TaxNumber { get; set; }

    [Column("DISPLAY_NAME")]
    public string? DisplayName { get; set; }

    [Column("EMAIL")]
    public string? Email { get; set; }

    [Column("WORK_PHONE")]
    public string? WorkPhone { get; set; }

    [Column("PERSONAL_PHONE")]
    public string? PersonalPhone { get; set; }

    [Column("WEBSITE")]
    public string? Website { get; set; }

    [Column("BILLING_ADDRESS1")]
    public string? BillingAddress1 { get; set; }

    [Column("BILLING_ADDRESS2")]
    public string? BillingAddress2 { get; set; }

    [Column("BILLING_ADDRESS_CITY")]
    public string? BillingAddressCity { get; set; }

    [Column("BILLING_ADDRESS_COUNTRY")]
    public string? BillingAddressCountry { get; set; }

    [Column("BILLING_ADDRESS_EMAIL")]
    public string? BillingAddressEmail { get; set; }

    [Column("BILLING_ADDRESS_POSTCODE")]
    public string? BillingAddressPostcode { get; set; }

    [Column("BILLING_ADDRESS_PHONE")]
    public string? BillingAddressPhone { get; set; }

    [Column("BILLING_ADDRESS_STATE")]
    public string? BillingAddressState { get; set; }

    [Column("SHIPPING_ADDRESS1")]
    public string? ShippingAddress1 { get; set; }

    [Column("SHIPPING_ADDRESS2")]
    public string? ShippingAddress2 { get; set; }

    [Column("SHIPPING_ADDRESS_CITY")]
    public string? ShippingAddressCity { get; set; }

    [Column("SHIPPING_ADDRESS_COUNTRY")]
    public string? ShippingAddressCountry { get; set; }

    [Column("SHIPPING_ADDRESS_EMAIL")]
    public string? ShippingAddressEmail { get; set; }

    [Column("SHIPPING_ADDRESS_POSTCODE")]
    public string? ShippingAddressPostcode { get; set; }

    [Column("SHIPPING_ADDRESS_PHONE")]
    public string? ShippingAddressPhone { get; set; }

    [Column("SHIPPING_ADDRESS_STATE")]
    public string? ShippingAddressState { get; set; }

    [Column("NOTE")]
    public string? Note { get; set; }

    [Column("ACTIVE")]
    public bool? Active { get; set; }

    [Column("CREATED_AT")]
    public DateTime? CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTime? UpdatedAt { get; set; }
}
