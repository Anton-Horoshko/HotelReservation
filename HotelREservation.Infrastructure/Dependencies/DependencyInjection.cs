using HotelReservation.Domain.Interfaces;
using HotelREservation.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelREservation.Infrastructure.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        return services;
    }
}
