using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUsersLibraryRepository
    {
        Task<int> AddUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<UsersLibrary> GetUsersLibraryByIdAsync(int id);

        Task<List<UsersLibrary>> GetAllUsersLibrariesAsync();

        Task<int> UpdateUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<int> DeleteUsersLibraryAsync(UsersLibrary usersLibrary);
    }
}
