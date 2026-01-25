using System.Text.Json.Serialization;

namespace Dotland.DotCapital.WebApi.Application.Customers.DTOs;

public class GetCustomersResponse(IEnumerable<CustomerDto> customers, int total, int page, int pageSize)
{
    [JsonPropertyName("customers")]
    public IEnumerable<CustomerDto> Customers { get; set; } = customers;

    [JsonPropertyName("pagination")]
    public PaginationMeta Pagination { get; set; } = new()
    {
        Total = total,
        Page = page,
        PageSize = pageSize
    };

    [JsonPropertyName("filter_meta")]
    public FilterMeta FilterMeta { get; set; } = new()
    {
        Order = "desc",
        FieldKey = "created_at"
    };

    // Hardcoded for now based on user request "field_key": "created_at", "order": "desc"
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
