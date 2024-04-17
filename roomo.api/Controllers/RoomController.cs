using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room.api.Domain.Entities;
using roomo.api.Data;
using roomo.api.Domain.Dto;
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
        public async Task<ActionResult<IEnumerable<RoomListDto>>> GetRooms()
        {
            IQueryable<RoomListDto> rooms =
                from r in _context.room
                join s in _context.cleaning_status on r.cleaning_status_id equals s.id into rsJoin
                from s in rsJoin.DefaultIfEmpty()
                join st in _context.status on r.status_id equals st.id into rsStatus
                from st in rsStatus.DefaultIfEmpty()
                select new RoomListDto
                {
                    id = r.id,
                    price = r.price,
                    number_of_beds = r.number_of_beds,
                    number_of_people = r.number_of_people,
                    status_id = r.status_id,
                    cleaning_status_id = r.cleaning_status_id,
                    room_no = r.room_no,

                    //LeftJoin
                    status_name = st.status_name,
                    cleaning_status_name = s.status_name

                }; ;
            return Ok(rooms.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoom(Guid id)
        {
            IQueryable<RoomListDto> room =
                (from r in _context.room
                join s in _context.cleaning_status on r.cleaning_status_id equals s.id into rsJoin
                from s in rsJoin.DefaultIfEmpty()
                join st in _context.status on r.status_id equals st.id into rsStatus
                from st in rsStatus.DefaultIfEmpty()
                where r.id == id
                select new RoomListDto
                {
                    id = r.id,
                    price = r.price,
                    number_of_beds = r.number_of_beds,
                    number_of_people = r.number_of_people,
                    status_id = r.status_id,
                    cleaning_status_id = r.cleaning_status_id,
                    room_no = r.room_no,
                    //LeftJoin
                    status_name = st.status_name,
                    cleaning_status_name = s.status_name

                });
            return Ok(room.ToList());
        }

            [HttpPut("")]
        public async Task<IActionResult> PutRoom(Rooms room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool RoomExists(Guid id)
        {
            return _context.room.Any(e => e.id == id);
        }

        [HttpPut("status")]
        public async Task<IActionResult> PutRoomStatus(RoomStatusDto roomStatusPost)
        {
            var room = await _context.room.FindAsync(roomStatusPost.id);
            room.status_id = roomStatusPost.status_id;
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
              
            }

            return NoContent();
        }
        [HttpPut("statusCleaning")]
        public async Task<IActionResult> PutRoomStatusCleaning(RoomStatusCleaningDto roomStatusCleaningPost)
        {
            var room = await _context.room.FindAsync(roomStatusCleaningPost.id);
            room.cleaning_status_id = roomStatusCleaningPost.cleaning_status_id;
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }

            return NoContent();
        }

    }
}
