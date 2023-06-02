using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSAPI.src;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace POSAPI.Controllers
{
    [Route("pos/")]                                 
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly Model _model;

        public UserController(Model model)
        {
            _model = model;
        }

        [Route("register")]
        [HttpPost]
        public ActionResult<String> Register([FromBody] UserDetails newuser)
        
        {
            var checkUserName = _model.UserDetails.Any(e => e.Username.Equals(newuser.Username));
            var checkDisplayName = _model.UserDetails.Any(u => u.DisplayName.Equals(newuser.DisplayName)) ; 
            if (checkUserName == true) {
                return BadRequest("Username already taken; Please use another User Name"); 
               }if (checkDisplayName == true)
            {
                return BadRequest("Display already taken; Please use another Display Name");
            }else
            {
                _model.UserDetails.Add(newuser);
            }

            try
            {
                _model.SaveChanges();
               
                return Ok("Successfully Added.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, Couldnt add to database. Please try again");
            }
        }

        [Route("login")]
        [HttpPut("Login")]
        public ActionResult<String> Login([FromBody] UserRequest LoginDetails)
        {
            
            var usern = _model.SystemUsers.FirstOrDefault(user => user.Username.Equals(LoginDetails.Username) && (user.Password.Equals(LoginDetails.Password)));

            if (usern != null)
            {
                return Ok(new String("Successfully Logged in"));
            }
            return NotFound("Invalid Login details");    
          
        } 
    }
}
