namespace HotelReservation.Application.DTO;

public class ReservationDTO
{
    public Guid Id { get; set; }
    public string ClientPhoneNumber { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long RoomId { get; set; }
}
