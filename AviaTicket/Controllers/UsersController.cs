using AviaTicket.Helpers;
using AviaTicket.Model.Users;
using AviaTicket.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace AviaTicket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUser userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(UserCreateModel model)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.CreateAsync(model)
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAsync(id)
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.GetAllAsync()
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await userService.DeleteAsync(id)
        });
    }
}
