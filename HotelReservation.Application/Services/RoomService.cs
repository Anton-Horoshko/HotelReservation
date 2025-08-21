using HotelReservation.Application.Services.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces;
using HotelREservation.Infrastructure.Repositories;

namespace HotelReservation.Application.Services;

public class RoomService : IRoomService
{
    public RoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task CreateAsync(Room room)
    {
        await _unitOfWork.Rooms.AddAsync(room);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        await _unitOfWork.Rooms.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<Room?> GetByIdAsync(long id)
        => _unitOfWork.Rooms.GetByIdAsync(id);

    public Task<List<Room>> GetByReservationIdAsync(Guid reservationId)
        => _unitOfWork.Rooms.GetByReservationIdAsync(reservationId);

    public Task<IEnumerable<Room>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }
}
