using Microsoft.AspNetCore.Mvc;
using Zestora.Application.Interfaces;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;

namespace Zestora.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _userService;

    public CustomerController(ICustomerService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _userService.CreateUser(user);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ValidateUserResponse>> ValidateUser(ValidateUserRequest req)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _userService.ValidateUser(req);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<GetAllActiveUsersResponse>> GetAllActiveUsers()
    {
        var result = await _userService.GetAllActiveUsers();
        return Ok(result);
    }
}
