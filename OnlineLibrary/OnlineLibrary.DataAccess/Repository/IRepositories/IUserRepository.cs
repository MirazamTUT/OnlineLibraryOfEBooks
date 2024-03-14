using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        public Task<User> GetUserByUserNameAsync(string userName);

        Task<List<User>> GetAllUsersAsync();

        Task<int> DeleteUserAsync(User user);
    }
}
