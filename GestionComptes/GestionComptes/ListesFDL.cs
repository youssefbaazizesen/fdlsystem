using System.ComponentModel.DataAnnotations;


namespace FDLsys
{
    public class ListesFDL
    {
        
        public int Id { get; set; }//this is the NFDL


        public int FDay_time { get; set; } = 0;
        public int Fnight_time { get; set; } = 0;
        public int FDay_desert_time { get; set; } = 0;
        public int Fnight_desert_time { get; set; } = 0;

        public int year { get; set; } = 0;
        public int month { get; set; } = 0;

        public string airplane_reg { get; set; }=string.Empty;

        public string captain_remarks { get; set; }=string.Empty ;

        public int total_block { get; set; } =0;
        public int total_airborn { get; set; }=0;
        public int deadhead { get; set; } = 0;


        public int Edition_number { get; set; } = 0;
        public sbyte validation { get; set; } = 0; //Ecrire à clavier un si validé 1 ou bien 0 si n'est pas encore validé

        public string MatriculeId { get; set; } 

        public List<Sequences> Sequences { get; set; }
    }
}
