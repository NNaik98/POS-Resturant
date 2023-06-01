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
    [Route("api/services")]                                 
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly Model _model;

        public UserController(Model model)
        {
            _model = model;
        }

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
