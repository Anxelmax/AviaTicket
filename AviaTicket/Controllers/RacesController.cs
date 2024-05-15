using AviaTicket.Helpers;
using AviaTicket.Model.Races;
using AviaTicket.Service.Services.Races;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController(IRace raceService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(RaceCreateModel model)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await raceService.CreateAsync(model)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await raceService.DeleteAsync(id)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await raceService.GetAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await raceService.GetAllAsync()
            });
        }
    }
}
