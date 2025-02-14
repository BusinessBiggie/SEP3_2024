namespace UserMicroservice.Interface_adapters.REST.DTOs;

public class LocationResponseDto
{
    public int LocationID { get; set; }
    public string StreetName { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}