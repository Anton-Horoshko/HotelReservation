namespace HotelReservation.Application.DTO;

public class RoomDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public List<Guid> ReservationsIds { get; set; } = new();
}
