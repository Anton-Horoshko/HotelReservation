using HotelReservation.Domain.Entities;

namespace HotelReservation.Domain.Interfaces;

public interface IReservationRepository
{
    Task<Reservation?> GetByIdAsync(Guid id);
    Task<IEnumerable<Reservation>> GetAllWithPaginationAsync(int pageSize, int pageNumber);
    Task AddAsync(Reservation reservation);
    Task DeleteAsync(Guid id);
    Task<List<Reservation>> GetByRoomIdAsync(long roomId);
}
