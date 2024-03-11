using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.Repository.IRepositories
{
    public interface IEBookRepository
    {
        Task<int> AddEBookAsync(EBook eBook);

        Task<EBook> GetEBookByIdAsync(int id);

        Task<List<EBook>> GetAllEBooksAsync();

        Task<int> UpdateEBookAsync(EBook eBook);

        Task<int> DeleteEBookAsync(EBook eBook);
    }
}
