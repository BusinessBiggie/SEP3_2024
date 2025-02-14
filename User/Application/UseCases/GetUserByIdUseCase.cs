using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases
{
    public class GetUserByIdUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Opdateret metode til at hente en bruger baseret på ID, nu asynkron
        public async Task<User?> Execute(int id)
        {
            // Brug den asynkrone metode til at hente brugeren fra repositoryet
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
    }
}