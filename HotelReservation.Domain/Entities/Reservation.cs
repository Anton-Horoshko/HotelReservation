namespace HotelReservation.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public string ClientPhoneNumber { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public long RoomId { get; set; }
    public Room Room { get; set; } = null!;
}
