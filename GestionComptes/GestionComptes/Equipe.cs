namespace FDLsys
{
    public class Equipe
    {
        public string Id { get; set; }
        public char cle { get; set; }
        public int fonction { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
