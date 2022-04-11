/*using FDLsys.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var AVGblock = _context.listesfdl.Average(fdl => fdl.total_block);
            return Ok(AVGblock);
        }

        [HttpGet("Average over all airborn time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllAirbornAVG()
        {
            //Parcour dans la table listefdl
            var AVGairborn = _context.listesfdl.Average(fdl => fdl.total_airborn);
            return Ok(AVGairborn);
        }

        [HttpGet("Average over all left over fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllleftoverfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGleftoverfuel = _context.Sequences.Average(seq => seq.remaining_fuel_from_previous);
            return Ok(AVGleftoverfuel);
        }

        [HttpGet("Average over all remaining fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllremainingfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGremainingfuel = _context.Sequences.Average(seq => seq.remaining_fuel);
            return Ok(AVGremainingfuel);
        }

        [HttpGet("Average over all added fuel"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAlladdedfuelavg()
        {
            //Parcour dans la table listefdl
            var AVGaddedfuel = _context.Sequences.Average(seq => seq.added_fuel);
            return Ok(AVGaddedfuel);
        }

        [HttpGet("Average over all block time"), Authorize(Roles = "CDB,Admin")]
        public async Task<ActionResult<ListesFDL>> OverAllfavg()
        {
            //Parcour dans la table listefdl
            var AVGremainingfuel = _context.Sequences.Average(seq => seq.remaining_fuel);
            return Ok(AVGremainingfuel);
        }

    }
}*/
