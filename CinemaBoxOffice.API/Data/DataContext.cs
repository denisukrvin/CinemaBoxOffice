using Microsoft.EntityFrameworkCore;
using CinemaBoxOffice.API.Models.User;
using CinemaBoxOffice.API.Models.Session;
using CinemaBoxOffice.API.Models.Reservation;

namespace CinemaBoxOffice.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<SessionModel> Sessions { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionModel>()
                .HasOne(s => s.Reservation)
                .WithOne(r => r.Session)
                .HasForeignKey<ReservationModel>(r => r.SessionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}