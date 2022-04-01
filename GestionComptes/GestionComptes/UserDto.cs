using System.ComponentModel.DataAnnotations;

namespace FDLsys
{
    public class UserDto
    {
        //Cette classe ne sera pas stocké sur la base de données , c'est l'input de l'API
        [Key]
        public string Matricule { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        
    }
}
