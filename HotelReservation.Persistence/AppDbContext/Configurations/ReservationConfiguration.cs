using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Persistence.AppDbContext.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(re => re.Id);
        builder.Property(re => re.ClientPhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        builder.Property(re => re.StartTime)
            .IsRequired();
        builder.Property(re => re.EndTime)
            .IsRequired();
        builder.Property(re => re.CreatedAt)
            .HasDefaultValueSql("NOW()");
        builder.HasOne(re => re.Room)
            .WithMany(ro => ro.Reservations)
            .HasForeignKey(re => re.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
