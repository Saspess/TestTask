using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Repositories.Interfaces;

namespace TestTask.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _appContext;

        public UserRepository(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<List<User>> GetUsers() =>
            await _appContext.Users
            .AsNoTracking()
            .Where(u => u.Status == UserStatus.Inactive)
            .ToListAsync();

        public async Task<User> GetUser() =>
            await _appContext.Users
            .AsNoTracking()
            .OrderByDescending(u => u.Orders.Count())
            .FirstOrDefaultAsync();
    }
}
