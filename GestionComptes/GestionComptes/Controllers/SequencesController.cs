using FDLsys.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDLsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequencesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public SequencesController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpGet ("Get FDL ")]
        public async Task<ActionResult<List<Sequences>>> Get(int nfdl)
        {
            var fdl = await _context.Sequences.Where(c => c.listefdl.Id == nfdl).ToListAsync();
            return fdl;
        }

        [HttpPost("rempliresequences")]
        public async Task<ActionResult<List<Sequences>>> Create(SequencesDto request)
        {
            
            var fdl = await _context.listesfdl.FindAsync(request.listesfdlId);
            if(fdl == null)         
                return BadRequest("List with such number was not found");

            var nouvelleSequence = new Sequences
            {
                expected_dep_time = request.expected_dep_time,

                bt_in_hour = request.bt_in_hour,
                bt_out_hour = request.bt_out_hour,
                bt_in_minute = request.bt_in_minute,
                bt_out_minute = request.bt_out_minute,
                block_time = Calcul_BlockTime(request.bt_in_hour, request.bt_out_hour, request.bt_in_minute, request.bt_out_minute),

                ab_on_hour = request.ab_on_hour,
                ab_off_hour = request.ab_off_hour,
                ab_on_minute = request.ab_on_minute,
                ab_off_minute = request.ab_off_minute,
                airborn_time = Calcul_AirbornTime(request.ab_on_hour, request.ab_off_hour, request.ab_on_minute, request.ab_off_minute),


                remaining_fuel_from_previous = request.remaining_fuel_from_previous,
                added_fuel = request.added_fuel,
                remaining_fuel = request.remaining_fuel,
                fuel_at_departure = request.remaining_fuel_from_previous + request.added_fuel,
                used_fuel = (request.remaining_fuel + request.added_fuel) - request.remaining_fuel,
                uplift = (float)(request.added_fuel * 0.8), //a liter of kerosen is about 0.8 kilogram
                listefdl = fdl

            };

            _context.Sequences.Add(nouvelleSequence);
            await _context.SaveChangesAsync();
            return Ok(nouvelleSequence);
           // return await Get(request.listesfdlId);


        }
        [HttpPut("Modify a sequence"),Authorize(Roles ="CDB,Admin")]
        public async Task<ActionResult<List<Sequences>>> Modify(Sequences request)
        {
            var fdl = await _context.listesfdl.FindAsync(request.listesfdlID);
            if (fdl == null)
                return BadRequest("List with such number was not found");

            var seq = await _context.Sequences.FindAsync(request.Id);
            if (seq == null)
                return BadRequest("Invalid sequence Number");
            var to_update_sequence = new Sequences
            {
                expected_dep_time = request.expected_dep_time,

                bt_in_hour = request.bt_in_hour,
                bt_out_hour = request.bt_out_hour,
                bt_in_minute = request.bt_in_minute,
                bt_out_minute = request.bt_out_minute,
                block_time = Calcul_BlockTime(request.bt_in_hour, request.bt_out_hour, request.bt_in_minute, request.bt_out_minute),

                ab_on_hour = request.ab_on_hour,
                ab_off_hour = request.ab_off_hour,
                ab_on_minute = request.ab_on_minute,
                ab_off_minute = request.ab_off_minute,
                airborn_time = Calcul_AirbornTime(request.ab_on_hour, request.ab_off_hour, request.ab_on_minute, request.ab_off_minute),


                remaining_fuel_from_previous = request.remaining_fuel_from_previous,
                added_fuel = request.added_fuel,
                remaining_fuel = request.remaining_fuel,
                fuel_at_departure = request.remaining_fuel_from_previous + request.added_fuel,
                used_fuel = (request.remaining_fuel + request.added_fuel) - request.remaining_fuel,
                uplift = (float)(request.added_fuel * 0.8), //a liter of kerosen is about 0.8 kilogram
                listefdl = fdl

            };

            
            await _context.SaveChangesAsync();
            return Ok(to_update_sequence);
        }


        private int Calcul_BlockTime(int end_hour, int arrive_hour, int btinmins, int start_mins)
        {
            if (end_hour < arrive_hour)
            {
                return (((end_hour + (24 - arrive_hour)) * 60) + (btinmins + (60 - start_mins)));
            }
            else
            {
                return (((end_hour - arrive_hour) * 60) + (btinmins + (60 - start_mins)));
            }
        }
        private int Calcul_AirbornTime(int ab_on_hours, int ab_off_hours, int abonmins, int aboffmins)
        {
            if (ab_on_hours < ab_off_hours)
            {
                return (((ab_on_hours + (24 - ab_off_hours)) * 60) + (abonmins + (60 - aboffmins)));
            }
            else
            {
                return (((ab_on_hours - ab_off_hours) * 60) + (abonmins + (60 - aboffmins)));
            }
        }
    }
}
