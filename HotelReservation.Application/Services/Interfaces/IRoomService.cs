using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services.Interfaces;

public interface IRoomService
{
    Task<IEnumerable<Room>> GetWithPaginationAsync(int pageNumber, int pageSize);
    Task<List<Room>> GetByReservationIdAsync(Guid reservationId);
    Task<Room?> GetByIdAsync(long id);
    Task CreateAsync(Room room);
    Task DeleteAsync(long id);
}