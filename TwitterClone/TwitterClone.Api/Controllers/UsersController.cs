using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers()
    {
        var user1 = new User(
          Guid.NewGuid(),
          "harry_potter@gmail.com",
          "Harry Potter",
          "Harry",
          DateTime.UtcNow,
          Guid.NewGuid()
        );

        var user2 = new User(
         Guid.NewGuid(),
         "percy_jackson@gmail.com",
         "Percy Jackson",
         "Percy",
         DateTime.UtcNow,
         Guid.NewGuid()
       );

        var user3 = new User(
          Guid.NewGuid(),
          "frodo_baggins@gmail.com",
          "Frodo Baggins",
          "Frodo",
          DateTime.UtcNow,
          Guid.NewGuid()
        );

        return Ok(new List<User>
{
  user1, user2, user3
});
    }
}
