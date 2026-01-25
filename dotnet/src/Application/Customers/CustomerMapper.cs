using Dotland.DotCapital.WebApi.Application.Customers.DTOs;
using Dotland.DotCapital.WebApi.Domain.Entities.Tenant;
using Riok.Mapperly.Abstractions;

namespace Dotland.DotCapital.WebApi.Application.Customers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class CustomerMapper
{
    [MapProperty(nameof(CreateCustomerDto.TaxeNumber), nameof(Contact.TaxNumber))]
    public partial Contact ToContact(CreateCustomerDto dto);

    [MapProperty(nameof(EditCustomerDto.TaxeNumber), nameof(Contact.TaxNumber))]
    [MapProperty(nameof(EditCustomerDto.CustomerType), nameof(Contact.ContactType))]
    public partial void UpdateContact(EditCustomerDto dto, Contact contact);

    public CustomerDto ToCustomerDto(Contact contact)
    {
        var dto = MapToCustomerDto(contact);
        dto.ClosingBalance = contact.Balance ?? 0;
        dto.LocalOpeningBalance = (contact.OpeningBalance ?? 0) * (contact.OpeningBalanceExchangeRate ?? 1);
        return dto;
    }

    private partial CustomerDto MapToCustomerDto(Contact contact);

    public IQueryable<CustomerDto> ProjectToCustomerDto(IQueryable<Contact> contacts)
    {
        return contacts.Select(c => new CustomerDto
        {
            Id = c.Id,
            ContactService = c.ContactService,
            ContactType = c.ContactType,
            Balance = c.Balance ?? 0,
            CurrencyCode = c.CurrencyCode,
            OpeningBalance = c.OpeningBalance ?? 0,
            OpeningBalanceAt = c.OpeningBalanceAt ?? DateTime.MinValue,
            OpeningBalanceExchangeRate = c.OpeningBalanceExchangeRate ?? 0,
            OpeningBalanceBranchId = c.OpeningBalanceBranchId ?? 0,
            Salutation = c.Salutation,
            FirstName = c.FirstName,
            LastName = c.LastName,
            CompanyName = c.CompanyName,
            RegistrationNumber = c.RegistrationNumber,
            TaxNumber = c.TaxNumber,
            DisplayName = c.DisplayName,
            Email = c.Email,
            WorkPhone = c.WorkPhone,
            PersonalPhone = c.PersonalPhone,
            Website = c.Website,
            BillingAddress1 = c.BillingAddress1,
            BillingAddress2 = c.BillingAddress2,
            BillingAddressCity = c.BillingAddressCity,
            BillingAddressCountry = c.BillingAddressCountry,
            BillingAddressEmail = c.BillingAddressEmail,
            BillingAddressPostcode = c.BillingAddressPostcode,
            BillingAddressPhone = c.BillingAddressPhone,
            BillingAddressState = c.BillingAddressState,
            ShippingAddress1 = c.ShippingAddress1,
            ShippingAddress2 = c.ShippingAddress2,
            ShippingAddressCity = c.ShippingAddressCity,
            ShippingAddressCountry = c.ShippingAddressCountry,
            ShippingAddressEmail = c.ShippingAddressEmail,
            ShippingAddressPostcode = c.ShippingAddressPostcode,
            ShippingAddressPhone = c.ShippingAddressPhone,
            ShippingAddressState = c.ShippingAddressState,
            Note = c.Note,
            Active = c.Active ?? false,
            CreatedAt = c.CreatedAt ?? DateTime.MinValue,
            UpdatedAt = c.UpdatedAt ?? DateTime.MinValue,
            ClosingBalance = c.Balance ?? 0,
            LocalOpeningBalance = (c.OpeningBalance ?? 0) * (c.OpeningBalanceExchangeRate ?? 1)
        });
    }
}
