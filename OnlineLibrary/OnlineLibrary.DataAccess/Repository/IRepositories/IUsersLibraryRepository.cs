using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUsersLibraryRepository
    {
        Task<UsersLibrary> AddUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<UsersLibrary> GetUsersLibraryAsync(int id);

        Task<List<UsersLibrary>> GetAllUsersLibrariesAsync();

        Task<UsersLibrary> UpdateUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<UsersLibrary> DeleteUsersLibraryAsync(int id);
    }
}
