using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IRooms _IRooms;

        public RoomsController(IMapper IMapper, IRooms IRooms)
        {
            _IMapper = IMapper;
            _IRooms = IRooms;
        }

        [Authorize]
        [HttpGet("/api/get-rooms/{id:int}")]
        public async Task<IResult> GetsessionById(int id)
        {
            var rooms = await _IRooms.GetEntityById(id);
            var roomsMap = _IMapper.Map<RoomsViewModel>(rooms);

            return Results.Ok(roomsMap);
        }

        [Authorize]
        [HttpGet("/api/get-rooms-all")]
        public async Task<IResult> GetAllsession()
        {
            var rooms = await _IRooms.List();
            var roomsMap = _IMapper.Map<List<RoomsViewModel>>(rooms);

            return Results.Ok(roomsMap);
        }
    }
}
