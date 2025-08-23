using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces;
using HotelReservation.Persistence.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace HotelREservation.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly Context _context;

    public RoomRepository(Context context)
    {
        _context = context;
    }

    public async Task AddAsync(Room room)
        => await _context.Rooms.AddAsync(room);

    public async Task DeleteAsync(long id)
        => await _context.Rooms.Where(r => r.Id == id).ExecuteDeleteAsync();

    public async Task<List<Room>> GetAllWithPaginationAsync(int pageSize, int pageNumber)
    {
        var TotalCount = await _context.Rooms.CountAsync();
        var ElementsToSkip = (pageNumber - 1) * pageSize;
        if (TotalCount - ElementsToSkip < pageSize)
            pageSize = TotalCount - ElementsToSkip;
        return await _context.Rooms
            .Skip(ElementsToSkip)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(Room room)
        => await _context.Rooms
            .Where(r => r.Id == room.Id)
            .ExecuteUpdateAsync(r => r.SetProperty(r => r.Number, room.Number)
                                       .SetProperty(r => r.Floor, room.Floor)
                                        .SetProperty(r => r.UpdatedAt, DateTime.UtcNow));

    public async Task<Room?> GetByIdAsync(long id)
        => await _context.Rooms
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
}