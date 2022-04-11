namespace FDLsys
{
    public class SequencesDto
    {
        //les données à saisir par clavier
       

        public string expected_dep_time { get; set; }

        //Block time
        public int bt_in_minute { get; set; }
        public int bt_in_hour { get; set; }
        public int bt_out_minute { get; set; }
        public int bt_out_hour { get; set; }

        //Airborn time 
        public int ab_on_hour { get; set; }
        public int ab_off_hour { get; set; }
        public int ab_on_minute { get; set; }
        public int ab_off_minute { get; set; }

        //Fuel 
        public float remaining_fuel_from_previous { get; set; }
        public float added_fuel { get; set; }
        public float remaining_fuel { get; set; } 
    
        

        public int listesfdlId { get; set; } 
        public int flightId { get; set; } 
    }
}
