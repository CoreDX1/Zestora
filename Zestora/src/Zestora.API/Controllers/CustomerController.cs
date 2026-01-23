using Microsoft.AspNetCore.Mvc;
using Zestora.Application.Interfaces;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;

namespace Zestora.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly IUserService _userService;

    public CustomerController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserRes>> CreateUser(CreateUserReq user)
    {
        var result = await _userService.CreateUser(user);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ValidateUserRes>> ValidateUser(ValidateUserReq req)
    {
        var result = await _userService.ValidateUser(req);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<GetAllActiveUsersRes>> GetAllActiveUsers()
    {
        var result = await _userService.GetAllActiveUsers();
        return Ok(result);
    }
}
