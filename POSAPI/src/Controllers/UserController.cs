using Microsoft.AspNetCore.Mvc;
using POSAPI.Security;
using POSAPI.src;
using POSAPI.src.RequestModels;
using System;
using System.Linq;

namespace POSAPI.Controllers
{
    [Route("pos/users")]
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
        public ActionResult<string> Register([FromBody] RegisterRequest userDetails)
        {
            var isUsernameInUse = _model.SystemUsers.Any(e => e.Username.Equals(userDetails.Username));
            var isDisplayNameInUse = _model.SystemUsers.Any(u => u.DisplayName.Equals(userDetails.DisplayName));

            if (isUsernameInUse)
                return BadRequest("Username already taken; Please use another User Name");
            if (isDisplayNameInUse)
                return BadRequest("Display already taken; Please use another Display Name");

            var rolesFromRequest = userDetails.Role.Split(",");
            var roles = _model.Roles.Where(r => rolesFromRequest.Contains(r.Name.ToLower())).ToList();

            var userId = _model.GetNewId<SystemUser>();
            var newUser = new SystemUser(userId, userDetails, roles);

            try
            {
                _model.SystemUsers.Add(newUser);
                _model.SaveChanges();

                return Ok("Successfully Added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Server error, Couldnt add to database. Please try again");
            }
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginRequest loginDetails)
        {
            try
            {
                var user = _model.SystemUsers.First(u => u.Username.Equals(loginDetails.Username));
                var hashedPassword = SecurityHelper.GetHash(loginDetails.Password, loginDetails.Username + user.Id);
                var isPassCorrect = user.Password.Equals(hashedPassword);

                if (!isPassCorrect)
                    throw new InvalidOperationException();

                return Ok("Successfully Logged in");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                return NotFound("Invalid Login details");                                                   // SystemUsers.First(... throws an exception if username doesn't match. We manually throw if pass doesn't
            }
        }
    }
}
