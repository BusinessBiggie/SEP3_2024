using UserMicroservice.Domain.Entities;
using UserMicroservice.Interface_adapters.REST.DTOs;

namespace UserMicroservice.Application.Interfaces;

public interface ILocationRepository
{
    Task<Location> CreateLocationAsync(Location location);
    Task<Location?> GetLocationByIdAsync(int id);
    Task<IEnumerable<Location>> GetAllLocationsAsync();
    Task<Location?> UpdateLocationAsync(int id, Location location);
    Task<bool> DeleteLocationAsync(int id);
}