using HotelReservation.Application.Mapping;
using HotelReservation.Application.Services;
using HotelReservation.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservation.Application.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRoomService, RoomService>();
        return services;
    }
}