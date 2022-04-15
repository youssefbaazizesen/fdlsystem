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

        [HttpGet("Average over all block time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllBlockAVG()
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
        /**/
    }
}