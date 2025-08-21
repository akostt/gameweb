using GameWeb.API.Contracts;
using GameWeb.Application;
using GameWeb.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _userService;

    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("byid/{id:int}")]
    public async Task<ActionResult<User?>> GetById(int id)
    {
        _logger.LogInformation("Getting user with id {id}", id);
        return await _userService.GetById(id);
    }
    
    [HttpGet("byname/{username}")]
    public async Task<ActionResult<User?>> GetByName(string username)
    {
        return await _userService.GetByName(username);
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateUserRequest request)
    {
        var user = new User
        {
            Username = request.Username,
            Password = request.Password
        };

        await _userService.Add(user);
        return Ok();
    }
}