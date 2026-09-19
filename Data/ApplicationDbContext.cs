using Microsoft.EntityFrameworkCore;
using MovieBooking.API.Models;

namespace MovieBooking.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
     public DbSet<Theater> Theaters { get; set; }
     public DbSet<Screen> Screens { get; set; }
     public DbSet<Seat> Seats { get; set; }
     public DbSet<Show> Shows { get; set; }
     public DbSet<User> Users { get; set; }
     public DbSet<Booking> Bookings { get; set; }
     public DbSet<BookingSeat> BookingSeats { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
   // User → Booking
modelBuilder.Entity<Booking>()
    .HasOne(b => b.User)
    .WithMany()
    .HasForeignKey(b => b.UserId)
    .OnDelete(DeleteBehavior.NoAction);

// Show → Booking
modelBuilder.Entity<Booking>()
    .HasOne(b => b.Show)
    .WithMany()
    .HasForeignKey(b => b.ShowId)
    .OnDelete(DeleteBehavior.NoAction);

// Booking → BookingSeat
modelBuilder.Entity<BookingSeat>()
    .HasOne(bs => bs.Booking)
    .WithMany()
    .HasForeignKey(bs => bs.BookingId)
    .OnDelete(DeleteBehavior.Cascade);

// Seat → BookingSeat
modelBuilder.Entity<BookingSeat>()
    .HasOne(bs => bs.Seat)
    .WithMany()
    .HasForeignKey(bs => bs.SeatId)
    .OnDelete(DeleteBehavior.NoAction);

// Screen → Seat
modelBuilder.Entity<Seat>()
    .HasOne(s => s.Screen)
    .WithMany()
    .HasForeignKey(s => s.ScreenId)
    .OnDelete(DeleteBehavior.NoAction);

// Screen → Show
modelBuilder.Entity<Show>()
    .HasOne(sh => sh.Screen)
    .WithMany()
    .HasForeignKey(sh => sh.ScreenId)
    .OnDelete(DeleteBehavior.NoAction);
}
 
}