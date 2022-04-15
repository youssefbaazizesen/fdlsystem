using FDLsys.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDLsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewListsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public ViewListsController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

       
        [HttpGet("Search sequences of a list id")]
        public async Task<ActionResult<Sequences>> Get_sequences(int Id)//Id est le numero de la feuille de ligne
        {
            var searched_list = await _context.listesfdl.FindAsync(Id);
            if (searched_list == null)
            {
                return BadRequest("list with such ID doesnt exist");
            }
            //Requette LINQ qui affiche toutes les sequences contenu dans la feuille de ligne ayant le numero "ID"
            var fdl = _context.Sequences.Include(fl =>fl.Flight).Where(s => s.listesfdlID == Id).ToList();



            /*
            var seqfdl = (from f in _context.listesfdl
                          join sq in _context.Sequences
                          on f.Id equals sq.listefdl.Id
                          where sq.listefdl.Id == Id
                          select new
                          {
                              totalblocktime = sq.block_time
                          }).Sum(t => t.totalblocktime);
            */



            return Ok(fdl);
        }


    }
    
}
