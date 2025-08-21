using HotelReservation.Domain.Interfaces;
using HotelReservation.Persistence.AppDbContext;

namespace HotelREservation.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IRoomRepository Rooms { get; }
    public IReservationRepository Reservations { get; }

    public UnitOfWork(Context context)
    {
        _context = context;
        Rooms = new RoomRepository(_context);
        Reservations = new ReservationRepository(_context);
    }

    private readonly Context _context;

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}