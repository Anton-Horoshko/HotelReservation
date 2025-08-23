namespace HotelReservation.Application.DTO;

public class RoomDetailsDTO
{   
    public long Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public List<ReservationShortDTO> Reservations { get; set; } = new();
}
