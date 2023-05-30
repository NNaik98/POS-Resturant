using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCoreAPI.Controllers
{
    [Route("api/services")]                                 // exposes routes to manage service templates
    [ApiController]
    [Produces("application/json")]
    public class ServiceController : ControllerBase
    {
        private readonly Model _model;

        public ServiceController(Model model)
        {
            _model = model;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<String> GetServiceSnapshotsForTemplate([FromRoute] string serviceTemplateId)
        {

            return Ok(new String("API works dont work"));

        }
    }
}
