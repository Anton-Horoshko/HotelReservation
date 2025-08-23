namespace HotelReservation.Application.DTO;

public class CreateReservationDTO
{
    public string ClientPhoneNumber { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public long RoomId { get; set; } 
}