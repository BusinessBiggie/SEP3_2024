using UserMicroservice.Application.Interfaces;

namespace UserMicroservice.Application.UseCases.LocationUsecases;

public class DeleteLocationUseCase
{
    private readonly ILocationRepository _locationRepository;

    public DeleteLocationUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<bool> Execute(int id)
    {
        return await _locationRepository.DeleteLocationAsync(id);
    }
}