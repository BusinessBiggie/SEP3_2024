namespace DTOs;


public class ListingDto
{
    public int ListingID { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    
    public string Condition { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int SellerId { get; set; }
    public string SellerName { get; set; }
}

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}