using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookMarksController : ControllerBase
{
    //temporary in-memory storage for bookmarks
    private static readonly List<Bookmark> _bookmarks = new();

    //Get api/bookmarks
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_bookmarks);
    }

    // GET api/bookmarks/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var bookmark = _bookmarks.FirstOrDefault(x => x.Id == id);
        if (bookmark == null)
        {
            return NotFound();
        }

        return Ok(bookmark);
    }

    // POST api/bookmarks
    [HttpPost]
    public IActionResult Create(Bookmark bookmark)
    {
        _bookmarks.Add(bookmark);
        return CreatedAtAction(nameof(GetById), new { id = bookmark.Id }, bookmark);
    }

    // PUT api/bookmarks/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Bookmark updated)
    {
        var bookmark = _bookmarks.FirstOrDefault(x => x.Id == id);
        if (bookmark == null)
        {
            return NotFound();
        }

        bookmark.UserId = updated.UserId;
        bookmark.TweetId = updated.TweetId;
        return Ok(bookmark);
    }

    // DELETE api/bookmarks/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var bookmark = _bookmarks.FirstOrDefault(x => x.Id == id);
        if (bookmark == null)
        {
            return NotFound();
        }

        _bookmarks.Remove(bookmark);
        return NoContent();
    }
}

