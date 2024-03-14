using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IUsersLibraryRepository
    {
        Task AddUsersLibraryAsync(UsersLibrary usersLibrary);

        Task<UsersLibrary> GetUsersLibraryByIdWithFileAsync(int id);

        Task<UsersLibrary> GetUsersLibraryByIdWithoutFileAsync(int id);

        Task<List<UsersLibrary>> GetAllUsersLibrariesWithoutFileAsync();

        Task<int> UpdateUsersLibraryAsync(UsersLibrary usersLibrary);

        Task DeleteUsersLibraryAsync(UsersLibrary usersLibrary);
    }
}
