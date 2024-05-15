using AviaTicket.Helpers;
using AviaTicket.Model.Seats;
using AviaTicket.Service.Services.Seats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController(ISeat seatService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(SeatCreateModel model)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await seatService.CreateAsync(model)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await seatService.DeleteAsync(id)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await seatService.GetAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await seatService.GetAllAsync()
            });
        }
    }
}
