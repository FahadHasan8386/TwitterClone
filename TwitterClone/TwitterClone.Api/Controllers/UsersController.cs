using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Repository;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class UsersController : ControllerBase
{
    private readonly UserRepository _userRepository;

    public UsersController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userRepository.GetUsers();

        var user  = users.Select (users => new UserDto
        {
            Id = users.Id,
            FirstName = users.FirstName,
            LastName = users.LastName,
            Email = users.Email
        });
        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName) || string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest("First name, last name, and email are required.");
        }

        var existingUser = _userRepository.GetUserByEmail(request.Email);

        if (existingUser != null)
        {
            return BadRequest("A user with that email already exists.");
        }

        // Create the new user
        var newUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        _userRepository.AddUser(newUser);

        var userDto = new UserDto
        {
            Id = newUser.Id,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Email = newUser.Email
        };
        return Ok(userDto);
    }

    // /api/users/{id}
    [HttpGet("{id}")]
    public IActionResult GetUserById([FromRoute] Guid id)
    {
        var user = _userRepository.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        return Ok(userDto);
    }


    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = _userRepository.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        var existingEmailUser = _userRepository.GetUserById(id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        _userRepository.UpdateUser(user);

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        return Ok(userDto);
    }


    // PATCH /api/users/{id}/phoneNumber
    [HttpPatch("{id}/phoneNumber")]
    public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
    {
        return Ok("hello");

    }

    // DELETE /api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        var user = _userRepository.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        var isDeleted = _userRepository.DeleteUser(user);

        return Ok(isDeleted);
    }
}
