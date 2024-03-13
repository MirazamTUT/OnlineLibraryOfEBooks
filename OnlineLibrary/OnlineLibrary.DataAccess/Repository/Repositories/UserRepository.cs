using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineLibrary.DataAccess.DbConnection;
using OnlineLibrary.DataAccess.Models;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.DataAccess.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OnlineLibraryDbContext _onlineLibraryDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(OnlineLibraryDbContext context, ILogger<UserRepository> logger)
        {
            _onlineLibraryDbContext = context;
            _logger = logger;
        }

        public async Task<int> AddUserAsync(User user)
        {
            try
            {
                _onlineLibraryDbContext.Users.Add(user);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Added User to DB.");
                return user.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was adding changes.");
            }
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _onlineLibraryDbContext.Users
                    .AsSplitQuery()
                    .FirstOrDefaultAsync();
                _logger.LogInformation("User was found.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                var allUsers = await _onlineLibraryDbContext.Users
                .AsSplitQuery()
                .ToListAsync();
                _logger.LogInformation("All Users were found.");
                return allUsers;
            }
            catch(Exception ex)
            {
                _logger.LogError($"There is an error retrieving all Users from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            try
            {
                _onlineLibraryDbContext.Users.Attach(user);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Updated User from DB.");
                return user.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }

        public async Task<int> DeleteUserAsync(User user)
        {
            try
            {
                _onlineLibraryDbContext.Users.Remove(user);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Deleted User from DB.");
                return user.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the User: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
