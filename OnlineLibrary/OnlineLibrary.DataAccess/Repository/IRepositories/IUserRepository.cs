using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<List<User>> GetAllUsersAsync();

        Task<int> UpdateUserAsync(User user);

        Task<int> DeleteUserAsync(User user);
    }
}
