using UserMicroservice.Application.Interfaces;

namespace UserMicroservice.Application.UseCases
{
    public class DeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(int userId)
        {
            // Hent brugeren fra repository
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return false; // Bruger blev ikke fundet
            }

            // Slet brugeren
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}