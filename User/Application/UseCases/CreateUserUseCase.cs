using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Opdateret metode til at oprette en ny bruger, nu asynkron
        public async Task<User> Execute(string username, string password, string firstname, string lastname, string email, int? locationId = null)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Password = hashedPassword,
                Firstname = firstname,
                Lastname = lastname,
                Email = email
            };

            // Brug af asynkron metode til at oprette bruger
            await _userRepository.CreateUserAsync(user);

            return user;
        }
    }
}