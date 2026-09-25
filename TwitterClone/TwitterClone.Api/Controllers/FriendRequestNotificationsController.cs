using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendRequestNotificationsController : ControllerBase
{
    // temporary in-memory storage
    private static readonly List<FriendRequestNotification> _friendRequestNotifications = new();

    // GET api/friendrequestnotifications
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_friendRequestNotifications);
    }

    // GET api/friendrequestnotifications/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var friendRequestNotification = _friendRequestNotifications.FirstOrDefault(x => x.Id == id);
        if (friendRequestNotification == null)
        {
            return NotFound();
        }

        return Ok(friendRequestNotification);
    }

    // POST api/friendrequestnotifications
    [HttpPost]
    public IActionResult Create(FriendRequestNotification friendRequestNotification)
    {
        _friendRequestNotifications.Add(friendRequestNotification);
        return CreatedAtAction(nameof(GetById), new { id = friendRequestNotification.Id }, friendRequestNotification);
    }

    // PUT api/friendrequestnotifications/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, FriendRequestNotification updated)
    {
        var friendRequestNotification = _friendRequestNotifications.FirstOrDefault(x => x.Id == id);
        if (friendRequestNotification == null)
        {
            return NotFound();
        }

        friendRequestNotification.UserId = updated.UserId;
        friendRequestNotification.IsRead = updated.IsRead;
        friendRequestNotification.RequestedByUserId = updated.RequestedByUserId;
        return Ok(friendRequestNotification);
    }

    // DELETE api/friendrequestnotifications/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var friendRequestNotification = _friendRequestNotifications.FirstOrDefault(x => x.Id == id);
        if (friendRequestNotification == null)
        {
            return NotFound();
        }

        _friendRequestNotifications.Remove(friendRequestNotification);
        return NoContent();
    }
}
