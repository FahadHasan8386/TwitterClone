using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FollowsController : ControllerBase
{
    // temporary in-memory storage
    private static readonly List<Follow> _follows = new();

    // GET api/follows
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_follows);
    }

    // GET api/follows/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var follow = _follows.FirstOrDefault(x => x.Id == id);
        if (follow == null)
        {
            return NotFound();
        }

        return Ok(follow);
    }

    // POST api/follows
    [HttpPost]
    public IActionResult Create(Follow follow)
    {
        _follows.Add(follow);
        return CreatedAtAction(nameof(GetById), new { id = follow.Id }, follow);
    }

    // PUT api/follows/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Follow updated)
    {
        var follow = _follows.FirstOrDefault(x => x.Id == id);
        if (follow == null)
        {
            return NotFound();
        }

        follow.FollowerId = updated.FollowerId;
        follow.FollowingId = updated.FollowingId;
        return Ok(follow);
    }

    // DELETE api/follows/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var follow = _follows.FirstOrDefault(x => x.Id == id);
        if (follow == null)
        {
            return NotFound();
        }

        _follows.Remove(follow);
        return NoContent();
    }
}
