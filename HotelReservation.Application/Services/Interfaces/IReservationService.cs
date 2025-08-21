using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Services.Interfaces;

public interface IReservationService
{
    Task<IEnumerable<Reservation>> GetWithPaginationAsync(int pageNumber, int pageSize);
    Task<List<Reservation>> GetByRoomIdAsync(long roomId);
    Task<Reservation?> GetByIdAsync(Guid id);
    Task CreateAsync(Reservation reservation);
    Task DeleteAsync(Guid id);
}
