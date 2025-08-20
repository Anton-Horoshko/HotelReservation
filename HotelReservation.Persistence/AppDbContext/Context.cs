using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HotelReservation.Persistence.AppDbContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
                : base(options) { }

    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
