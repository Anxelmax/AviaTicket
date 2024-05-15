using AviaTicket.Helpers;
using AviaTicket.Model.Tickets;
using AviaTicket.Service.Services.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AviaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicket ticketService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(TicketCreateModel model)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await ticketService.CreateAsync(model)
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await ticketService.DeleteAsync(id)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await ticketService.GetAsync(id)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await ticketService.GetAllAsync()
            });
        }
    }
}
