using System.Text.Json.Serialization;

namespace FDLsys
{
    public class Equipe
    {
        public int Id { get; set; }
        public char cle { get; set; }
        public int fonction { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int FlightId { get; set; }
        
    }
}
