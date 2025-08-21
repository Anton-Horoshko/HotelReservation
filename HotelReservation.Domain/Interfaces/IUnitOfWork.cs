namespace HotelReservation.Domain.Interfaces;

public interface IUnitOfWork
{
    IRoomRepository Rooms { get; }
    IReservationRepository Reservations { get; }

    Task<int> SaveChangesAsync();
}
