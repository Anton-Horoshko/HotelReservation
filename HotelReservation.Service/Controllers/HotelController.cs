using AutoMapper;
using HotelReservation.Application.DTO;
using HotelReservation.Application.Services.Interfaces;
using HotelReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    public HotelController(IReservationService reservationService, IRoomService roomService, IMapper mapper)
    {
        _reservationService = reservationService;
        _roomService = roomService;
        _mapper = mapper;
    }
    private readonly IReservationService _reservationService;
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    [HttpGet("ListOfRooms")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRooms(int pageNumber = 1, int pageSize = 10)
    {
        var rooms = await _roomService.GetWithPaginationAsync(pageNumber, pageSize);
        var mappedRooms = _mapper.Map<List<RoomDTO>>(rooms);
        return Ok(mappedRooms);
    }

    [HttpGet("RoomDetails")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRoomDetails(long id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        var mappedRoom = _mapper.Map<RoomDetailsDTO>(room);
        return Ok(mappedRoom);
    }

    [HttpPost("CreateReservation")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDTO createReservationDto)
    {
        if (createReservationDto == null)
        {
            return BadRequest("Reservation data is required.");
        }
        var reservation = _mapper.Map<Reservation>(createReservationDto);
        await _reservationService.CreateAsync(reservation);
        return NoContent();
    }

    [HttpPost("CreateRoom")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO createRoomDto)
    {
        if (createRoomDto == null)
        {
            return BadRequest("Room data is required.");
        }
        var room = _mapper.Map<Room>(createRoomDto);
        await _roomService.CreateAsync(room);
        return NoContent();
    }

    [HttpDelete("DeleteReservation")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteReservation(Guid id)
    {
        var reservation = await _reservationService.GetByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }
        await _reservationService.DeleteAsync(id);
        return NoContent();
    }

    [HttpDelete("DeleteRoom")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRoom(long id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        await _roomService.DeleteAsync(id);
        return NoContent();
    }
}