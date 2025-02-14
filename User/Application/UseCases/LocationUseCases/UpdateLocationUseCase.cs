using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Interface_adapters.REST.DTOs;

namespace UserMicroservice.Application.UseCases.LocationUsecases;

public class UpdateLocationUseCase
{
    private readonly ILocationRepository _locationRepository;

    public UpdateLocationUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Location?> Execute(int id, LocationDto locationDto)
    {
        var existingLocation = await _locationRepository.GetLocationByIdAsync(id);
        if (existingLocation == null) return null;

        // Update fields
        existingLocation.StreetName = locationDto.StreetName;
        existingLocation.HouseNumber = locationDto.HouseNumber;
        existingLocation.PostalCode = locationDto.PostalCode;
        existingLocation.City = locationDto.City;
        existingLocation.Country = locationDto.Country;
        existingLocation.Region = locationDto.Region;

        return await _locationRepository.UpdateLocationAsync(id, existingLocation);
    }
}