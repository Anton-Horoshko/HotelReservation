using HotelReservation.Domain.Entities;

namespace HotelReservation.Domain.Interfaces;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(long id);
    Task<IEnumerable<Room>> GetAllWithPaginationAsync(int pageSize, int pageNumber);
    Task<List<Room>> GetByReservationIdAsync(Guid reservationId);
    Task AddAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(long id);
}
