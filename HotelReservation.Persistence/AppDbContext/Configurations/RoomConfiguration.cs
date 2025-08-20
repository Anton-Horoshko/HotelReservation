using HotelReservation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation.Persistence.AppDbContext.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(ro => ro.Id);
        builder.Property(ro => ro.Number)
            .IsRequired();
        builder.Property(ro => ro.Floor)
            .IsRequired();
        builder.Property(ro => ro.CreatedAt)
            .HasDefaultValueSql("NOW()");
        builder.Property(ro => ro.UpdatedAt)
            .HasDefaultValueSql("NOW()");
        builder.HasMany(ro => ro.Reservations)
            .WithOne(re => re.Room)
            .HasForeignKey(re => re.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}