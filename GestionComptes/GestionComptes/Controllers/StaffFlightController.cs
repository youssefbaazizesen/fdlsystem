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
        [HttpPost("Importflight")]
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
        [HttpPut("modifyflight")]
        public async Task<ActionResult<Flight>> modifyexistantflight(Flight request)
        {
            var to_change_flight = await _context.Flight.FindAsync(request.Id);
            if (to_change_flight == null)
                return BadRequest("Flight does not exist");
            to_change_flight.Id = request.Id;
            to_change_flight.cie = request.cie;
            to_change_flight.datevol = request.datevol;
            to_change_flight.escalARR = request.escalARR;
            to_change_flight.escalDEP = request.escalDEP;
            
            await _context.SaveChangesAsync();
            return Ok(to_change_flight);
        }

        [HttpPost("importstaff")]
        public async Task<ActionResult<Equipe>>importstaff(Equipe request)
        {
            
            var staff = new Equipe();
            staff.cle=request.cle;
            staff.first_name=request.first_name;
            staff.last_name=request.last_name;
            staff.fonction=request.fonction;
            
            staff.FlightId=request.FlightId;
            

            _context.Equipes.Add(staff);
            await _context.SaveChangesAsync();
            return Ok(staff);

        }[HttpPut("modifystaff")]
        public async Task<ActionResult<Equipe>>modifystaff(Equipe request)
        {

            var staff = await _context.Equipes.FindAsync(request.Id);
            if (staff == null)
                return BadRequest("staff member does not exist");

            
            staff.cle=request.cle;
            staff.first_name=request.first_name;
            staff.last_name=request.last_name;
            staff.fonction=request.fonction;
            
            staff.FlightId=request.FlightId;
            

            
            await _context.SaveChangesAsync();
            return Ok(staff);

        }
    }



}
