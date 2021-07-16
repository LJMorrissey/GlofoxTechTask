using GlofoxTechTask.Models.Request;
using GlofoxTechTask.Extensions;
using Microsoft.AspNetCore.Mvc;
using GlofoxTechTask.BookClass;
using GlofoxTechTask.BookClass.Models;

namespace GlofoxTechTask.Controllers
{
    [ApiController]
    public class Bookingcontroller : ControllerBase
    {

        private readonly ClassBookingClient _bookingClient;

        public Bookingcontroller(ClassBookingClient bookingClient)
        {
            _bookingClient = bookingClient;
        }

        [HttpPost]
        [Route("/booking")]
        public IActionResult bookNewStudioClass([FromBody] ClassBookingRequest request)
        {
            // need a middleware to handle uncought exceptions or try catch?  come back to this

            if (request == null) return BadRequest();
            if (request.ClientName.IsNullOrWhiteSpace()) return BadRequest("Invalid ClientName provided");
            if (request.ClassName.IsNullOrWhiteSpace()) return BadRequest("Invalid ClassName provided");
            if (request.ClassDate.ToString().IsNullOrWhiteSpace()) return BadRequest("Invalid ClassDate provided");
            if (request.ClassDate == default) return BadRequest("Invalid ClassDate provided"); ;
           
            var bookingRequest = new ClassBookingDetails()
            {
                ClientName = request.ClientName,
                ClassName = request.ClassName,
                ClassDate = request.ClassDate
            };

            var response = _bookingClient.BookClass(bookingRequest);

            if (response)
            {
                return Ok("Class Booked Successfully");
            }
            else
            {
                return StatusCode(500, "Something went wrong booking your class, please try again. If problem persists please contact your customer support representitive");
            }

        }
    }
}
