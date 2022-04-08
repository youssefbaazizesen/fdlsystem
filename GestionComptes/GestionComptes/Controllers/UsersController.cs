using FDLsys.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FDLsys.Controllers
{
    //CREATION DE CONROLLEUR DES TOKENS
    //UN TOKEN EST UN JETON DE RETOUR LORD D'UNE AUTHENTIFICATION
    //UNE AUTHENTIFICATION EST UNE OPEARTION QUI CONFIRME L'IDENTIT2 DE L'UTILISATEUR
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static Users user =new Users();
        private static List<Users> users = new List<Users>() { };

        
        
           
        
        
        //CONSTRUCTEUR
        //ICONFIGURATION FAIT L'APPEL A appsettings.json
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public UsersController(IConfiguration configuration,DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        //CREATION DE PROFILS
        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(UserDto request)
        {
            var sys_user = new Users();
            CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);
            sys_user.Username=request.Username;
            sys_user.Passwordhash = passwordhash;
            sys_user.PassworSalt=passwordsalt;
            sys_user.Role=request.Role;
            sys_user.Matricule=request.Matricule;
            
            _context.Users.Add(sys_user);
            await _context.SaveChangesAsync();
            return Ok(sys_user);
        }
        //METHODE LOGIN /POST
        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login(UserDto request)
        {
            var logingUser = await _context.Users.FindAsync(request.Matricule);
            if (logingUser == null)
            {
                return BadRequest(" Matricule not found please verify Matricule");
            }
          /*  if (logingUser.Username != request.Username)
            {
                return BadRequest("User name not correct please verify your User name");
            }
            if (logingUser.Role != request.Role)
            {
                return BadRequest("Role not correct please verify your role");
            }
            */
            if (!VerifyPasswordHash(request.Password, logingUser.Passwordhash, logingUser.PassworSalt))
            {
                return BadRequest("Verify your password");
            }
            string token = CreateToken(logingUser);
            return Ok(token);
            
            
        }

        //Show All User Info
        [HttpGet("Get all Users")]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        //Search for a user using Username
        [HttpGet ("Search a user")]
        public async Task<ActionResult<Users>> Get(int Matricule)
        {
            var user=await _context.Users.FindAsync(Matricule);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        //Update User
        [HttpPut("Update a User")]
        public async Task<ActionResult<List<Users>>> UpdateUser(UserDto request)
        {
            var To_Update_User = await _context.Users.FindAsync(request.Matricule);
            if (To_Update_User== null)
            {
                return BadRequest("User not found please verify the User name");
            }
            CreatePasswordHash(request.Password, out byte[] passwordhash, out byte[] passwordsalt);
            To_Update_User.Username = request.Username;
            To_Update_User.Passwordhash = passwordhash;
            To_Update_User.PassworSalt = passwordsalt;
            To_Update_User.Role = request.Role;
            To_Update_User.Matricule = request.Matricule;

            await _context.SaveChangesAsync();

            return Ok(To_Update_User);
        }
        [HttpDelete("Delete a User")]
        
        //Delete a User
        public async Task<ActionResult<List<Users>>>DeleteUser(UserDto request)
        {
            var To_Delete_User = await _context.Users.FindAsync(request.Matricule);
            if (To_Delete_User == null)
            {
                return BadRequest("Matricule String not found please verify user's matricule");
            }
             _context.Users.Remove(To_Delete_User);
            await _context.SaveChangesAsync();
            return Ok("User with Matricule"+request.Matricule+"has been deleted");
        }
        private string CreateToken(Users user)
        {
            //les tokens sont basé sur les claims definit ici (role et Matricule)
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Matricule),
                new Claim(ClaimTypes.Role,user.Role)

        };
            // a token must have a secure key
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)) ;
            var credit = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:credit);
               
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        //cryptage d'un mot de passe
        private void CreatePasswordHash(string password,out byte[] passwordhash,out byte[] passwordsalt)
        {
            using(var hmac= new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        //methode de verification d'un mot de passe crypté
        private bool VerifyPasswordHash(string password,byte[] passwordhash,byte[] passwordsalt)
            {
        using (var hmac = new HMACSHA512(passwordsalt))
            {
                var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computehash.SequenceEqual(passwordhash);
                
            }
            }
    }
    
}
