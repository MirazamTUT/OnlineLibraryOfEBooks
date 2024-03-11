﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineLibrary.DataAccess.DbConnection;
using OnlineLibrary.DataAccess.Models;
using OnlineLibrary.DataAccess.Repository.IRepositories;

namespace OnlineLibrary.DataAccess.Repository.Repositories
{
    public class UsersLibraryRepository : IUsersLibraryRepository
    {
        private readonly OnlineLibraryDbContext _onlineLibraryDbContext;
        private readonly ILogger<UsersLibraryRepository> _logger;

        public UsersLibraryRepository(OnlineLibraryDbContext context, ILogger<UsersLibraryRepository> logger)
        {
            _onlineLibraryDbContext = context;
            _logger = logger;
        }

        public async Task<int> AddUsersLibraryAsync(UsersLibrary usersLibrary)
        {
            try
            {
                _onlineLibraryDbContext.UsersLibraries.Add(usersLibrary);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Added User's Library to DB.");
                return usersLibrary.UsersLibraryId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the User's Library: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was adding changes.");
            }
        }

        public async Task<UsersLibrary> GetUsersLibraryByIdAsync(int id)
        {
            try
            {
                var usersLibrary = await _onlineLibraryDbContext.UsersLibraries
                    .Include(x => x.EBooks)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(x => x.UsersLibraryId == id);
                _logger.LogInformation("User's Library was found.");
                return usersLibrary;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving User's Library from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<List<UsersLibrary>> GetAllUsersLibrariesAsync()
        {
            try
            {
                var allUsersLibraries = await _onlineLibraryDbContext.UsersLibraries
                    .Include(x => x.EBooks)
                    .AsSplitQuery()
                    .ToListAsync();
                _logger.LogInformation("All Users' Libraries were found.");
                return allUsersLibraries;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There is an error retrieving Users' Libraries from the database: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was giving the information.");
            }
        }

        public async Task<int> UpdateUsersLibraryAsync(UsersLibrary usersLibrary)
        {
            try
            {
                _onlineLibraryDbContext.UsersLibraries.Update(usersLibrary);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Updated User's Library from DB.");
                return usersLibrary.UsersLibraryId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the User's Library: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }

        public async Task<int> DeleteUsersLibraryAsync(UsersLibrary usersLibrary)
        {
            try
            {
                _onlineLibraryDbContext.UsersLibraries.Remove(usersLibrary);
                await _onlineLibraryDbContext.SaveChangesAsync();
                _logger.LogInformation("Deleted User's Library from DB.");
                return usersLibrary.UsersLibraryId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the User's Library: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
