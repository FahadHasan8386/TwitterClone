using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetweetsController : ControllerBase
{
    // temporary in-memory storage
    private static readonly List<Retweet> _retweets = new();

    // GET api/retweets
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_retweets);
    }

    // GET api/retweets/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var retweet = _retweets.FirstOrDefault(x => x.Id == id);
        if (retweet == null)
        {
            return NotFound();
        }

        return Ok(retweet);
    }

    // POST api/retweets
    [HttpPost]
    public IActionResult Create(Retweet retweet)
    {
        _retweets.Add(retweet);
        return CreatedAtAction(nameof(GetById), new { id = retweet.Id }, retweet);
    }

    // PUT api/retweets/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Retweet updated)
    {
        var retweet = _retweets.FirstOrDefault(x => x.Id == id);
        if (retweet == null)
        {
            return NotFound();
        }

        retweet.UserId = updated.UserId;
        retweet.TweetId = updated.TweetId;
        retweet.Comment = updated.Comment;
        return Ok(retweet);
    }

    // DELETE api/retweets/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var retweet = _retweets.FirstOrDefault(x => x.Id == id);
        if (retweet == null)
        {
            return NotFound();
        }

        _retweets.Remove(retweet);
        return NoContent();
    }
}
