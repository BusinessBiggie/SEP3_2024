namespace DTOs;

using System.ComponentModel.DataAnnotations;

public class CreateListingRequest
{
    [Required(ErrorMessage = "Product Name is required.")]
    [StringLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
    public string? ProductName { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10,000.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
    public string? Category { get; set; }
    
    [Required(ErrorMessage = "Condition is required.")]
    [StringLength(50, ErrorMessage = "Condition cannot exceed 50 characters.")]
    public string? Condition { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    public string? SellerName { get; set; } // No validation here
    public int SellerId { get; set; } = 0;

    public string? ImageUrl { get; set; }
}