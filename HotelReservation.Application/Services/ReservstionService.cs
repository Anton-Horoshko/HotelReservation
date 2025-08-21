using HotelReservation.Application.Services.Interfaces;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Interfaces;
using HotelREservation.Infrastructure.Repositories;

namespace HotelReservation.Application.Services;

public class ReservstionService : IReservationService
{

    public ReservstionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task CreateAsync(Reservation reservation)
    {
        await _unitOfWork.Reservations.AddAsync(reservation);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.Reservations.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<Reservation?> GetByIdAsync(Guid id)
        => _unitOfWork.Reservations.GetByIdAsync(id);

    public Task<List<Reservation>> GetByRoomIdAsync(long roomId)
        => _unitOfWork.Reservations.GetByRoomIdAsync(roomId);

    public Task<IEnumerable<Reservation>> GetWithPaginationAsync(int pageNumber, int pageSize)
        => _unitOfWork.Reservations.GetAllWithPaginationAsync(pageNumber, pageSize);
}
