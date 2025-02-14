using System.Text.Json.Serialization;

namespace UserMicroservice.Domain.Entities;

public class Location
{
    public int LocationID { get; set; } // Primær nøgle
    public string StreetName { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;

    // Relation til User
    public int UserID { get; set; } // Foreign Key
    [JsonIgnore] 
    public User User { get; set; } // Navigation Property

    public Location(string streetName, string houseNumber, string postalCode, string city, string region, string country)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
        City = city;
        Region = region;
        Country = country;
    }

    public Location()
    {
        // Parameterløs constructor til EF Core
    }
}