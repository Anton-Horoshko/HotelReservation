using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces;
using HotelReservation.Persistence.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace HotelREservation.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly Context _context;

    public ReservationRepository(Context context)
    {
        _context = context;
    }

    public async Task AddAsync(Reservation reservation)
        => await _context.Reservations.AddAsync(reservation);

    public async Task DeleteAsync(Guid id)
        => await _context.Reservations.Where(r => r.Id == id).ExecuteDeleteAsync();

    public async Task<IEnumerable<Reservation>> GetAllWithPaginationAsync(int pageSize, int pageNumber)
        => await _context.Reservations
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

    public Task<Reservation?> GetByIdAsync(Guid id)
        => _context.Reservations
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
}
