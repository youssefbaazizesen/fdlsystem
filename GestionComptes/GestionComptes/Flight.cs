using System.Text.Json.Serialization;

namespace FDLsys
{
    public class Flight
    {
        public int Id { get; set; }
        public string cie { get; set; }
        public string datevol { get; set; }
        public string escalDEP { get; set; }
        public string escalARR { get; set; }
      
    }
}
