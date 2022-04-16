using FDLsys.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDLsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public StatController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        //AVERAGE OVER ALL VALUES
        [HttpGet("Average over all block time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllBlockavg()
        {
            //Parcour dans la table listefdl
            var AVGblock = await _context.listesfdl.AverageAsync(fdl => fdl.total_block);
            return Ok(AVGblock.ToString());

        }
      
        [HttpGet("Average over all airborn time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllAirbornAVG()
        {
            //Parcour dans la table listefdl
            var AVGairborn = await _context.listesfdl.AverageAsync(fdl => fdl.total_airborn);
            return Ok(AVGairborn.ToString());
        }
        
        [HttpGet("Average over all left over fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllleftoverfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGleftoverfuel = await _context.Sequences.AverageAsync(seq => seq.remaining_fuel_from_previous);
            return Ok(AVGleftoverfuel.ToString());
        }

        [HttpGet("Average over all remaining fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllremainingfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGremainingfuel = await _context.Sequences.AverageAsync(seq => seq.remaining_fuel);
            return Ok(AVGremainingfuel.ToString());
        }
        
        [HttpGet("Average over all added fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlladdedfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGaddedfuel = await _context.Sequences.AverageAsync(seq => seq.added_fuel);
            return Ok(AVGaddedfuel.ToString());
        }

        [HttpGet("Average over all used fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllusedfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGusedfuel = await _context.Sequences.AverageAsync(seq => seq.used_fuel);
            return Ok(AVGusedfuel.ToString());
        }
        [HttpGet("Average over all uplift"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllupliftavg()
        {
            //Parcour dans la table listefdl
            var AVGuplift = await _context.Sequences.AverageAsync(seq => seq.uplift);
            return Ok(AVGuplift.ToString());
        }
        [HttpGet("Average over all day time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldaytimeavg()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.AverageAsync(f => f.FDay_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Average over all night time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllnighttimeavg()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.AverageAsync(f => f.Fnight_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Average over all desert night time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldesrtnighttimeavg()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.AverageAsync(f => f.Fnight_desert_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Average over all desert day time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldesrtdaytimeavg()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.AverageAsync(f => f.FDay_desert_time);
            return Ok(stat_value.ToString());
        }


        //OVER ALL SUM VALUES




        [HttpGet("Sum over all block time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllBlockSUM()
        {
            //Parcour dans la table listefdl
            var SUMblock = await _context.listesfdl.SumAsync(fdl => fdl.total_block);
            return Ok(SUMblock.ToString());

        }

        [HttpGet("Sum over all airborn time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllAirbornSUM()
        {
            //Parcour dans la table listefdl
            var SUMairborn = await _context.listesfdl.SumAsync(fdl => fdl.total_airborn);
            return Ok(SUMairborn.ToString());
        }

        [HttpGet("Sum over all left over fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllleftoverfuelsum()
        {
            //Parcour dans la table listefdl
            var SUMleftoverfuel = await _context.Sequences.SumAsync(seq => seq.remaining_fuel_from_previous);
            return Ok(SUMleftoverfuel.ToString());
        }

        [HttpGet("Sum over all remaining fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllremainingfuelsum()
        {
            
            var SUMremainingfuel = await _context.Sequences.SumAsync(seq => seq.remaining_fuel);
            return Ok(SUMremainingfuel.ToString());
        }

        [HttpGet("Sum over all added fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlladdedfuelsum()
        {
            //Parcour dans la table listefdl
            var SUMaddedfuel = await _context.Sequences.SumAsync(seq => seq.added_fuel);
            return Ok(SUMaddedfuel.ToString());
        }

        [HttpGet("Sum over all used fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllusedfuelsum()
        {
            //Parcour dans la table listefdl
            var SUMusedfuel = await _context.Sequences.SumAsync(seq => seq.used_fuel);
            return Ok(SUMusedfuel.ToString());
        }
        
        [HttpGet("Sum over all uplift"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllupliftsum()
        {
            //Parcour dans la table listefdl
            var SUMuplift = await _context.Sequences.SumAsync(seq => seq.uplift);
            return Ok(SUMuplift.ToString());
        }
        [HttpGet("Sum over all day time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldaytimesum()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.SumAsync(f => f.FDay_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Sum over all night time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllnighttimesum()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.SumAsync(f => f.Fnight_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Sum over all desert night time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldesrtnighttimesum()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.SumAsync(f => f.Fnight_desert_time);
            return Ok(stat_value.ToString());
        }
        [HttpGet("Sum over all desert day time flight"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlldesrtdaytimesum()
        {
            //Parcour dans la table listefdl
            var stat_value = await _context.listesfdl.SumAsync(f => f.FDay_desert_time);
            return Ok(stat_value.ToString());
        }

        //AVERAGE PER LOGGED IN PILOT
        [HttpGet("Average block time for logged pilot"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> PilotBlockavg()
        {
            var mat = User?.Identity?.Name;
            var stat_value= await _context.listesfdl.Where(f => f.MatriculeId== mat).AverageAsync(fdl => fdl.total_block);
            return Ok(stat_value.ToString());

        }


        /**/
    }
}