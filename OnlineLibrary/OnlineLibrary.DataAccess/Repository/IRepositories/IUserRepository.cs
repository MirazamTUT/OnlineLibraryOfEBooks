using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);

        Task<User> GetUserAsync(int id);

        Task<List<User>> GetAllUsersAsync();

        Task<User> UpdateUserAsync(int id);

        Task<User> DeleteUserAsync(int id);
    }
}
