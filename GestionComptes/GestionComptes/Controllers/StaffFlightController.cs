using FDLsys.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var imported_flight = new Flight();

            imported_flight.cie = request.cie;
            imported_flight.datevol = request.datevol;
            imported_flight.escalARR = request.escalARR;
            imported_flight.escalDEP = request.escalDEP;
                
            
            _context.Flight.Add(imported_flight);
           await _context.SaveChangesAsync();
            return Ok(imported_flight);
        }
        
    }
}
