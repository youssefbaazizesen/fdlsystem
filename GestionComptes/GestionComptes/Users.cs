using System.ComponentModel.DataAnnotations;

namespace FDLsys
{
    public class Users
    {
        //Cette classe serai l'output de l'API qui sera être stocké sur la base des données
        [Key]
        public string Matricule { get; set; }

        public string Username { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] PassworSalt { get; set; }
        public string Role { get; set; }
        

    }
}
