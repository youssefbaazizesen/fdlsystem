using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FDLsys
{
    public class Sequences
    {
        
        public int Id { get; set; }


        //JSON IGNORED DATA ARE CALCULATED IN THE CONTROLLER AND ARE NOT INPUT FROM USER.

        public int expected_dep_time { get; set; }
        public int bt_in_minute { get; set; }
        public int bt_in_hour { get; set; }
        public int bt_out_minute { get; set; }
        public int bt_out_hour { get; set; }
        [JsonIgnore]
        public int block_time { get; set; }

        public int ab_on_hour { get; set; }
        public int ab_off_hour { get; set; }
        public int ab_off_minute { get; set; }
        public int ab_on_minute { get; set; }
        [JsonIgnore]
        public int airborn_time { get; set; }

        //fuel data
        public float remaining_fuel_from_previous { get; set; }
        public float added_fuel { get; set; }
        public float remaining_fuel { get; set; }
        [JsonIgnore]
        public float fuel_at_departure { get; set; }
        [JsonIgnore]
        public float used_fuel { get; set; }
        [JsonIgnore]
        public float uplift { get; set; }       
        public int listesfdlID { get; set; }    
       [JsonIgnore]
        public ListesFDL listefdl { get; set; }
        

    }
}
