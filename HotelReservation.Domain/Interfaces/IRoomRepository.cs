using HotelReservation.Domain.Entities;

namespace HotelReservation.Domain.Interfaces;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(long id);
    Task<List<Room>> GetAllWithPaginationAsync(int pageSize, int pageNumber);
    Task AddAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(long id);
}
