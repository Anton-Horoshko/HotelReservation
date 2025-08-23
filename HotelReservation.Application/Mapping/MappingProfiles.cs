using AutoMapper;
using HotelReservation.Application.DTO;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRoomDTO, Room>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Reservations, opt => opt.Ignore());

        CreateMap<CreateReservationDTO, Reservation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Room, opt => opt.Ignore());

        CreateMap<Room, RoomDTO>()
            .ForMember(dest => dest.ReservationsIds,
                       opt => opt.MapFrom(src => src.Reservations.Select(r => r.Id).ToList()));

        CreateMap<Room, RoomDetailsDTO>()
            .ForMember(dest => dest.Reservations,
                       opt => opt.MapFrom(src => src.Reservations));

        CreateMap<Reservation, ReservationDTO>();

        CreateMap<Reservation, ReservationShortDTO>();
    }
}