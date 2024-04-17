using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room.api.Domain.Entities;
using roomo.api.Data;
using System.Net.Http;

namespace roomo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            return await _context.room.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoom(Guid id)
        {
            var room = await _context.room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }
    }
}
