using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces.Service;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetAllUsers();

        return Ok(users);
    }

    // POST: api/users
    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreateUser(
        [FromBody] CreateUserRequest request)
    {
        var userDto = _userService.CreateUser(request);

        return Ok(userDto);
    }

    // GET: api/users/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetUserById(
        [FromRoute] Guid id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // PUT: api/users/{id}
    [HttpPut("{id:guid}")]
    public IActionResult UpdateUser(
        [FromRoute] Guid id,
        [FromBody] UpdateUserRequest request)
    {
        var user = _userService.UpdateUser(id, request);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(
        [FromRoute] Guid id)
    {
        var isDeleted = _userService.DeleteUser(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}