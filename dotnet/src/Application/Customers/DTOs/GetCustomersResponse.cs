using System.Text.Json.Serialization;

namespace Dotland.DotCapital.WebApi.Application.Customers.DTOs;

public class GetCustomersResponse
{
    [JsonPropertyName("customers")]
    public IEnumerable<CustomerDto> Customers { get; set; }

    [JsonPropertyName("pagination")]
    public PaginationMeta Pagination { get; set; }

    [JsonPropertyName("filter_meta")]
    public FilterMeta FilterMeta { get; set; }

    public GetCustomersResponse(IEnumerable<CustomerDto> customers, int total, int page, int pageSize)
    {
        Customers = customers;
        Pagination = new PaginationMeta
        {
            Total = total,
            Page = page,
            PageSize = pageSize
        };
        // Hardcoded for now based on user request "field_key": "created_at", "order": "desc"
        FilterMeta = new FilterMeta
        {
            Order = "desc",
            FieldKey = "created_at"
        };
    }
}

public class PaginationMeta
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("page_size")]
    public int PageSize { get; set; }
}

public class FilterMeta
{
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    [JsonPropertyName("field_key")]
    public string? FieldKey { get; set; }
}
