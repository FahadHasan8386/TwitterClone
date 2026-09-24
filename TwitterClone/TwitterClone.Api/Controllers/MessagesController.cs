using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        // temporary in-memory storage
        private static readonly List<Message> _messages = new();

        // GET api/messages
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_messages);
        }

        // GET api/messages/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var message = _messages.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // POST api/messages
        [HttpPost]
        public IActionResult Create(Message message)
        {
            message.SentAt = DateTime.UtcNow; // set the time when the message is sent
            _messages.Add(message);
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        // PUT api/messages/{id}
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Message updated)
        {
            var message = _messages.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            message.SenderId = updated.SenderId;
            message.ReceiverId = updated.ReceiverId;
            message.Content = updated.Content;
            message.IsRead = updated.IsRead;
            return Ok(message);
        }

        // DELETE api/messages/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var message = _messages.FirstOrDefault(x => x.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            _messages.Remove(message);
            return NoContent();
        }
    }
}
