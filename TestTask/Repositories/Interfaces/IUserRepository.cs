using TestTask.Models;

namespace TestTask.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser();

        public Task<List<User>> GetUsers();
    }
}
