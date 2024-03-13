using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUsersLibraryRepository
    {
        Task<int> AddUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<UsersLibrary> GetUsersLibraryByIdWithoutFileAsync(int id);

        Task<List<UsersLibrary>> GetAllUsersLibrariesWithoutFileAsync();

        Task<int> UpdateUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<int> DeleteUsersLibraryAsync(UsersLibrary usersLibrary);
    }
}
