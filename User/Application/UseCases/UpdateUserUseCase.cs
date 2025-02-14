using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases
{
    public class UpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Opdateret metode til at opdatere en bruger, nu asynkron
        public async Task<User> Execute(int id, string username, string password, string firstname, string lastname, string email)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            // Opdater brugerens data
            user.Username = username;
            user.Password = password;
            user.Firstname = firstname;
            user.Lastname = lastname;
            user.Email = email;

            // Opdater brugeren i databasen
            await _userRepository.UpdateUserAsync(user);

            return user;
        }
    }
}