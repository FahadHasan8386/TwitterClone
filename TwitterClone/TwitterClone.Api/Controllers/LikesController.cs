using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        // temporary in-memory storage
        private static readonly List<Like> _likes = new();

        // GET api/likes
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_likes);
        }

        // GET api/likes/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var like = _likes.FirstOrDefault(x => x.Id == id);
            if (like == null)
            {
                return NotFound();
            }

            return Ok(like);
        }

        // POST api/likes
        [HttpPost]
        public IActionResult Create(Like like)
        {
            _likes.Add(like);
            return CreatedAtAction(nameof(GetById), new { id = like.Id }, like);
        }

        // PUT api/likes/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Like updated)
        {
            var like = _likes.FirstOrDefault(x => x.Id == id);
            if (like == null)
            {
                return NotFound();
            }

            like.UserId = updated.UserId;
            like.TweetId = updated.TweetId;
            return Ok(like);
        }

        // DELETE api/likes/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var like = _likes.FirstOrDefault(x => x.Id == id);
            if (like == null)
            {
                return NotFound();
            }

            _likes.Remove(like);
            return NoContent();
        }
    }
}
