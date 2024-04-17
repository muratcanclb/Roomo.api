using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room.api.Domain.Entities;
using roomo.api.Data;
using roomo.api.Domain.Dto;

namespace roomo.api.Controllers
{
    public class StatusController : Controller
    {
        private readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.status.ToListAsync();
        }
        [HttpGet("statusCleaning")]
        public async Task<ActionResult<IEnumerable<CleaningStatus>>> GetStatusCleaning()
        {
            return await _context.cleaning_status.ToListAsync();
        }
    }
}
