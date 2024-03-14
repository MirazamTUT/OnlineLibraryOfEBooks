using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineLibrary.DataAccess.DbConnection;
using OnlineLibrary.DataAccess.Models;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.DataAccess.Repository.Repositories
{
    public class EBookRepository : IEBookRepository
    {
        private readonly OnlineLibraryDbContext _onlineLibraryDbContext;
        private readonly ILogger<EBookRepository> _logger;

        public EBookRepository(OnlineLibraryDbContext context, ILogger<EBookRepository> logger)
        {
            _onlineLibraryDbContext = context;
            _logger = logger;
        }

        public async Task<int> AddEBookAsync(EBook eBook)
        {
            try
            {
                _onlineLibraryDbContext.EBooks.Add(eBook);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Added E-Book to DB.");
                return eBook.EBookId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was adding changes.");
            }
        }

        public async Task<EBook> GetEBookByIdAsync(int id)
        {
            try
            {
                var eBook = await _onlineLibraryDbContext.EBooks
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(x => x.EBookId == id);
                _logger.LogInformation("E-Book was found.");
                return eBook;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving E-Book from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<EBook> GetEBookByTitleAndAuthorAsync(string title, string author)
        {
            try
            {
                var eBook = await _onlineLibraryDbContext.EBooks
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(x => x.Title.Equals(title) && x.Author.Equals(author));
                _logger.LogInformation("E-Book was found.");
                return eBook;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving E-Book from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<List<EBook>> GetAllEBooksAsync()
        {
            try
            {
                var allEBooks = await _onlineLibraryDbContext.EBooks
                    .AsSplitQuery()
                    .ToListAsync();
                _logger.LogInformation("All E-Books were found.");
                return allEBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving all E-Books from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<List<EBook>> GetAllEBooksWithoutFileAsync()
        {
            try
            {   
                var allEBooks = await _onlineLibraryDbContext.EBooks
                    .AsSplitQuery()
                    .Select(e => new EBook
                    {
                        Title = e.Title,
                        EBookRatingStars = e.EBookRatingStars,
                        Author = e.Author,
                        Tags = e.Tags,
                        Description = e.Description
                    })
                    .ToListAsync();
                _logger.LogInformation("All E-Books were found.");
                return allEBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving all E-Books from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<int> UpdateEBookAsync(EBook eBook)
        {
            try
            {
                _onlineLibraryDbContext.EBooks.Attach(eBook);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Updated E-Book from DB.");
                return eBook.EBookId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }

        public async Task<int> DeleteEBookAsync(EBook eBook)
        {
            try
            {
                _onlineLibraryDbContext.EBooks.Remove(eBook);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Deleted E-Book from DB.");
                return eBook.EBookId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
