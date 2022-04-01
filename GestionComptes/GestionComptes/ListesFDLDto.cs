namespace FDLsys
{
    public class ListesFDLDto
    {
        //Flight time details
        public  int NFDL { get; set; }
        public int FDay_time { get; set; }
        public int Fnight_time { get; set; }
        public int FDay_desert_time { get; set; }
        public int Fnight_desert_time { get; set; }
        public int year { get; set; }
        public int month { get; set; }


        public int nbr_sequences { get; set; }

        public string airplane_reg { get; set; }//registre d'avion
        public string captain_remarks { get; set; }//remarques du capitaine

        public int deadblock { get; set; }

        //public List<Sequences> sequences { get; set; } 

        public int Edition_number { get; set; }
        public sbyte validation { get; set; }
    }
}
