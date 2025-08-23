using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services.Interfaces;

public interface IRoomService
{
    Task<List<Room>> GetWithPaginationAsync(int pageNumber, int pageSize);
    Task<Room?> GetByIdAsync(long id);
    Task CreateAsync(Room room);
    Task DeleteAsync(long id);
}