using System.Threading.Tasks;
using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.UseCases
{
    public class GetUserByEmailUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Execute(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user;
        }
    }
}