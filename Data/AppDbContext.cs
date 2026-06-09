using APBD_TEST2.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_TEST2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Hall> Halls => Set<Hall>();
        public DbSet<Screening> Screenings => Set<Screening>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.ScreeningId, t.CustomerId });

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Screening)
                .WithMany(s => s.Tickets)
                .HasForeignKey(t => t.ScreeningId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Hall)
                .WithMany(h => h.Screenings)
                .HasForeignKey(s => s.HallId);

            modelBuilder.Entity<Screening>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Screenings)
                .HasForeignKey(s => s.MovieId);
        }
    }
}
