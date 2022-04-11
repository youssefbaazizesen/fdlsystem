using FDLsys.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/*
namespace FDLsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffFlightController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public StaffFlightController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost("Import")]
        public async Task<ActionResult<Flight>> importflights(Flight request)
        {
            var seq = await _context.listesfdl.FindAsync(request.SequencesId);
            if (seq == null)
                return BadRequest("List with such number was not found");
        }

    }
}*/
