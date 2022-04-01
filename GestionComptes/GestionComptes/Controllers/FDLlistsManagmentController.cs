﻿using FDLsys.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FDLsys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDLlistsManagmentController : ControllerBase
    {

        //CONSTRUCTEUR
        //ICONFIGURATION FAIT L'APPEL A appsettings.json
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public FDLlistsManagmentController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        //Remplissage d'une nouvelle feuille de ligne
        [HttpPost ("remplirefdl"),Authorize(Roles ="CDB")]
        public async Task<ActionResult<ListesFDL>> Register(ListesFDLDto request)
        {
            
            var nouvelle_liste = new ListesFDL();

            nouvelle_liste.FDay_time = request.FDay_time;
            nouvelle_liste.Fnight_desert_time = request.Fnight_desert_time;
            nouvelle_liste.FDay_desert_time = request.FDay_desert_time;
            nouvelle_liste.Fnight_desert_time = request.Fnight_desert_time;

            nouvelle_liste.year = request.year;
            nouvelle_liste.month = request.month;

            nouvelle_liste.airplane_reg = request.airplane_reg;

            nouvelle_liste.captain_remarks = request.captain_remarks;
            nouvelle_liste.Edition_number++;
            nouvelle_liste.matricule_CDB = User?.Identity?.Name;
            
            nouvelle_liste.validation = request.validation;





            /*   
               nouvelle_liste.FDay_time=request.FDay_time;
               nouvelle_liste.Fnight_desert_time=request.Fnight_desert_time;
               nouvelle_liste.FDay_desert_time = request.FDay_desert_time;
               nouvelle_liste.Fnight_desert_time= request.Fnight_desert_time;

               nouvelle_liste.year=request.year;
               nouvelle_liste.month=request.month;

               nouvelle_liste.airplane_reg=request.airplane_reg; 

               nouvelle_liste.captain_remarks=request.captain_remarks;
               nouvelle_liste.Edition_number = 0;


               Console.WriteLine("This was compiled");

               for (int j = 0; j < request.nbr_sequences; j++)
               {

                   nouvelle_liste.Sequences[j].ab_off_hour = request.sequences[j].ab_off_hour;
                   nouvelle_liste.Sequences[j].ab_on_hour = request.sequences[j].ab_on_hour;
                   nouvelle_liste.Sequences[j].ab_on_minute=request.sequences[j].ab_on_minute;
                   nouvelle_liste.Sequences[j].ab_off_minute = request.sequences[j].ab_off_minute;
                   nouvelle_liste.Sequences[j].airborn_time = Calcul_Diffrence_Time(request.sequences[j].ab_on_hour, request.sequences[j].ab_off_hour, request.sequences[j].ab_on_minute, request.sequences[j].ab_off_minute);

                   nouvelle_liste.Sequences[j].bt_in_hour = request.sequences[j].bt_in_hour;
                   nouvelle_liste.Sequences[j].bt_in_minute=request.sequences[j].bt_in_minute;
                   nouvelle_liste.Sequences[j].bt_out_hour = request.sequences[j].bt_out_hour;
                   nouvelle_liste.Sequences[j].bt_out_minute=request.sequences[j].bt_out_minute;
                   nouvelle_liste.Sequences[j].block_time = Calcul_Diffrence_Time(request.sequences[j].bt_in_hour, request.sequences[j].bt_out_hour, request.sequences[j].bt_in_minute, request.sequences[j].bt_out_minute);

                   nouvelle_liste.Sequences[j].remaining_fuel_from_previous = request.sequences[j].remaining_fuel_from_previous;
                   nouvelle_liste.Sequences[j].remaining_fuel = request.sequences[j].remaining_fuel;
                   nouvelle_liste.Sequences[j].added_fuel = request.sequences[j].added_fuel;
                   nouvelle_liste.Sequences[j].fuel_at_departure = request.sequences[j].remaining_fuel_from_previous+ request.sequences[j].added_fuel;
                   nouvelle_liste.Sequences[j].used_fuel=(request.sequences[j].remaining_fuel_from_previous + request.sequences[j].added_fuel)- request.sequences[j].remaining_fuel ;
                   nouvelle_liste.Sequences[j].uplift = (float)(request.sequences[j].added_fuel * 0.8);

                   nouvelle_liste.Sequences[j].listefdl = nouvelle_liste;
                   _context.Sequences.Add(nouvelle_liste.Sequences[j]);
               }





               nouvelle_liste.total_airborn = nouvelle_liste.Sequences.Sum(s => s.airborn_time);
               */
            _context.listesfdl.Add(nouvelle_liste);
            await _context.SaveChangesAsync();
            return (Ok(nouvelle_liste));
        }

        [HttpPut ("Update a List"),Authorize(Roles ="CDB")]
        public async Task<ActionResult<List<ListesFDL>>> UpdateList(ListesFDLDto request)
        {
            var to_update_list = await _context.listesfdl.FindAsync(request.NFDL);
            if (to_update_list == null)
            {
                return BadRequest("list with such Number doesnt exist");
            }
            
            to_update_list.FDay_time = request.FDay_time;
            to_update_list.Fnight_desert_time = request.Fnight_desert_time;
            to_update_list.FDay_desert_time = request.FDay_desert_time;
            to_update_list.Fnight_desert_time = request.Fnight_desert_time;

            to_update_list.year = request.year;
            to_update_list.month = request.month;

            to_update_list.airplane_reg = request.airplane_reg;

            to_update_list.captain_remarks = request.captain_remarks;
            to_update_list.Edition_number++;
            to_update_list.matricule_CDB = User?.Identity?.Name;

            to_update_list.total_block = (from f in _context.listesfdl
                                          join sq in _context.Sequences
                                          on f.Id equals sq.listefdl.Id
                                          where sq.listefdl.Id == request.NFDL
                                          select new
                                          {
                                              totalblocktime = sq.block_time
                                          }).Sum(t => t.totalblocktime);
            to_update_list.total_airborn = (from f in _context.listesfdl
                                            join sq in _context.Sequences
                                            on f.Id equals sq.listefdl.Id
                                            where sq.listefdl.Id == request.NFDL
                                            select new
                                            {
                                                totalairtime = sq.airborn_time
                                            }).Sum(t => t.totalairtime);
            to_update_list.validation=request.validation;

            await _context.SaveChangesAsync();
            return (Ok(to_update_list));
        }
        [HttpPost("Chercher votres listes"), Authorize(Roles = "CDB")]
        public async Task<ActionResult<List<ListesFDL>>> GetLists()
        {
            return Ok("dd");
        }
       
        private int Calcul_Diffrence_Time(int end_hour, int start_hours, int end_mins, int start_mins)
        {
            if (end_hour < start_hours)
            {
                return (((end_hour + (24 - start_hours)) * 60) + (end_mins + (60 - start_mins)));
            }
            else
            {
                return (((end_hour - start_hours) * 60) + (end_mins + (60 - start_mins)));
            }
        }     
    }
}


