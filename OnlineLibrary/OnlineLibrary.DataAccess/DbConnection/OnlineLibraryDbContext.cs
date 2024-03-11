using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataAccess.Models;

namespace OnlineLibrary.DataAccess.DbConnection
{
    public class OnlineLibraryDbContext : DbContext
    {
        public OnlineLibraryDbContext(DbContextOptions<OnlineLibraryDbContext> options) :
            base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<EBook> EBooks { get; set; }

        public DbSet<UsersLibrary> UsersLibraries { get; set; }
    }
}
