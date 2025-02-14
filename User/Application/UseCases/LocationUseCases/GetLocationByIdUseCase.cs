using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases.LocationUsecases;

public class GetLocationByIdUseCase
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationByIdUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Location?> Execute(int id)
    {
        return await _locationRepository.GetLocationByIdAsync(id);
    }
}
