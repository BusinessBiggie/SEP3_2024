using Microsoft.EntityFrameworkCore;
using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Infrastructure.Persistence.Data;

namespace UserMicroservice.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly UserDbContext _context;

        public LocationRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location?> GetLocationByIdAsync(int id)
        {
            return await _context.Locations
                .Include(l => l.User) // Inkluder User, hvis det er nødvendigt
                .FirstOrDefaultAsync(l => l.LocationID == id);
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location?> UpdateLocationAsync(int id, Location location)
        {
            var existingLocation = await GetLocationByIdAsync(location.LocationID);
            if (existingLocation == null) return null;

            // Opdater felterne
            existingLocation.StreetName = location.StreetName;
            existingLocation.HouseNumber = location.HouseNumber;
            existingLocation.PostalCode = location.PostalCode;
            existingLocation.City = location.City;
            existingLocation.Country = location.Country;
            existingLocation.Region = location.Region;

            _context.Locations.Update(existingLocation);
            await _context.SaveChangesAsync();
            return existingLocation;
        }
        

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await GetLocationByIdAsync(id);
            if (location == null) return false;

            _context.Locations.Remove(location);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
