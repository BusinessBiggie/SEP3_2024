using DTOs;

namespace EcoUme.Services
{
    public interface IUsersService
    {
        Task<UserDTO?> GetUserByIdAsync(int userId);
        Task<UserDTO?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(CreateUserDTO createUserDTO);
        Task UpdateUserAsync(int userId, UpdateUserDTO updateUserDTO);
        Task DeleteUserAsync(int userId);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<LoginResponseDTO?> LoginAsync(LoginUserDTO loginUserDTO);
        Task<List<UserDTO>> GetAllUsersByListOfIdsAsync(List<int> userIds);
    }
}