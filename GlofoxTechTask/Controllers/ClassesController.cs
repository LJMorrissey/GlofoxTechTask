using GlofoxTechTask.Models.Request;
using GlofoxTechTask.Extensions;
using Microsoft.AspNetCore.Mvc;
using GlofoxTechTask.RegisterClassDetails;
using GlofoxTechTask.RegisterClassDetails.Models;

namespace GlofoxTechTask.Controllers
{
    [ApiController]
    public class ClassesController : ControllerBase
    {

        private readonly ClassRegistrationClient _registrationClient;

        public ClassesController(ClassRegistrationClient registrationClient)
        {
            _registrationClient = registrationClient;
        }

        [HttpPost]
        [Route("/classes")]
        public IActionResult RegisterNewStudioClass([FromBody] ClassRegistrationRequest request)
        {
            // need a middleware to handle uncought exceptions or try catch?  come back to this

            if (request == null) return BadRequest();
            if (request.ClassName.IsNullOrWhiteSpace()) return BadRequest("Invalid ClassName provided");
            if (request.StartDate.ToString().IsNullOrWhiteSpace()) return BadRequest("Invalid StartDate provided");
            if (request.StartDate == default) return BadRequest("Invalid StartDate provided");
            if (request.EndDate.ToString().IsNullOrWhiteSpace()) return BadRequest("Invalid EndDate provided");
            if (request.EndDate == default)  return BadRequest("Invalid EndDate provided"); ;
            if (request.Capacity.ToString().IsNullOrWhiteSpace()) return BadRequest("Invalid Capacity provided");
            if (request.Capacity == 0) return BadRequest("Invalid Capacity provided");

            var registrationRequest = new ClassRegistrationDetails()
            {
                ClassName = request.ClassName,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Capacity = request.Capacity
            };
             
            var response = _registrationClient.RegisterClass(registrationRequest);


            if (response)
            {
                return Ok("Class Registered Successfully");
            }
            else
            {
                return StatusCode(500, "Something went wrong registering your class, please try again. If problem persists please contact your customer support representitive");
            }

        }
    }
}
