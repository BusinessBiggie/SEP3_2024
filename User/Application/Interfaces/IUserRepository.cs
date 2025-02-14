namespace UserMicroservice.Application.Interfaces
{
    using UserMicroservice.Domain.Entities;

    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id); // Brug Guid her
        Task<User?> GetUserByEmailAsync(string email); // Email kan stadig være string
        Task UpdateUserAsync(User user);
        Task <bool> DeleteUserAsync(int id); // Brug Guid her
    }
}