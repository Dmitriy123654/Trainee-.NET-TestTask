using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUser()
        {
            var user = await _db.Users
                .AsNoTracking()
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefaultAsync();
            return user ?? new User();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _db.Users
                .AsNoTracking()
                .Where(u => u.Status == UserStatus.Inactive)
                .ToListAsync();
        }
    }
}
