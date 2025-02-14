namespace DTOs;

public class GetListingsRequest
{
    public int? SellerId { get; set; } // Optional filter by SellerId
    public string? Category { get; set; } // Optional filter by Category
}