using AviaTicket.Helpers;
using AviaTicket.Model.Airplanes;
using AviaTicket.Service.Services.Airplanes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController(IAirplane airplaneService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(AirplaneCreateModel model)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await airplaneService.CreateAsync(model)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await airplaneService.GetAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await airplaneService.GetAllAsync()
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await airplaneService.DeleteAsync(id)
            });
        }
    }
}
