using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Interface_adapters.REST.DTOs;

namespace UserMicroservice.Application.UseCases.LocationUsecases
{
    public class CreateLocationForUserUseCase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;

        public CreateLocationForUserUseCase(ILocationRepository locationRepository, IUserRepository userRepository)
        {
            _locationRepository = locationRepository;
            _userRepository = userRepository;
        }

        public async Task<Location> Execute(int userId, LocationDto locationDto)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                 throw new ArgumentException($"User with ID {userId} not found.");
            }

            var location = new Location
            {
                StreetName = locationDto.StreetName,
                HouseNumber = locationDto.HouseNumber,
                PostalCode = locationDto.PostalCode,
                City = locationDto.City,
                Country = locationDto.Country,
                Region = locationDto.Region,
                UserID = user.UserID
            };

            return await _locationRepository.CreateLocationAsync(location);
        }
    }
}
