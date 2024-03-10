using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IMainLibraryRepository
    {
        Task<MainLibrary> AddMainLibraryAsync(MainLibrary mainLibrary);
    }
}
