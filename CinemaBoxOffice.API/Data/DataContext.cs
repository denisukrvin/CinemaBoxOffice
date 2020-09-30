using Microsoft.EntityFrameworkCore;
using CinemaBoxOffice.API.Models.Session;

namespace CinemaBoxOffice.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<SessionModel> Sessions { get; set; }
    }
}