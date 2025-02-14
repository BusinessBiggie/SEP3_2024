using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases.LocationUsecases;

public class GetAllLocationsUseCase
{
    private readonly ILocationRepository _locationRepository;

    public GetAllLocationsUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<IEnumerable<Location>> Execute()
    {
        return await _locationRepository.GetAllLocationsAsync();
    }
}