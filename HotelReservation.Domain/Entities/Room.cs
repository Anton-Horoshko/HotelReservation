namespace HotelReservation.Domain.Entities;

public class Room
{
    public long Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Guid ReservationId { get; set; }
    public List<Reservation> Reservations { get; set; } = new();


}

