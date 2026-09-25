using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentNotificationsController : ControllerBase
{
    // temporary in-memory storage
    private static readonly List<CommentNotification> _commentNotifications = new();

    // GET api/commentnotifications
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_commentNotifications);
    }

    // GET api/commentnotifications/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var commentNotification = _commentNotifications.FirstOrDefault(x => x.Id == id);
        if (commentNotification == null)
        {
            return NotFound();
        }

        return Ok(commentNotification);
    }

    // POST api/commentnotifications
    [HttpPost]
    public IActionResult Create(CommentNotification commentNotification)
    {
        _commentNotifications.Add(commentNotification);
        return CreatedAtAction(nameof(GetById), new { id = commentNotification.Id }, commentNotification);
    }

    // PUT api/commentnotifications/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, CommentNotification updated)
    {
        var commentNotification = _commentNotifications.FirstOrDefault(x => x.Id == id);
        if (commentNotification == null)
        {
            return NotFound();
        }

        commentNotification.UserId = updated.UserId;
        commentNotification.IsRead = updated.IsRead;
        commentNotification.CommentByUserId = updated.CommentByUserId;
        return Ok(commentNotification);
    }

    // DELETE api/commentnotifications/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var commentNotification = _commentNotifications.FirstOrDefault(x => x.Id == id);
        if (commentNotification == null)
        {
            return NotFound();
        }

        _commentNotifications.Remove(commentNotification);
        return NoContent();
    }
}
