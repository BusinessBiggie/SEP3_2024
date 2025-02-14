using Microsoft.EntityFrameworkCore;
using UserMicroservice.Application.Interfaces;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Infrastructure.Persistence.Data;

namespace UserMicroservice.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            // Opdateret Include for at hente alle lokationer tilknyttet brugeren
            return await _context.Users
                .Include(u => u.Locations) // Brug Locations (1-til-mange relation)
                .FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}