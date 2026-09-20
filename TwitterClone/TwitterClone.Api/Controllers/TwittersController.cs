using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TweetsController : ControllerBase
    {

        private readonly IConfiguration _config;

        public TweetsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {

            string? maxLength = _config["TweetSettings:MaxTweetLength"];

            Tweet tweet = new Tweet(
              Guid.NewGuid(),
              Guid.NewGuid(),
              "This is a new tweet",
              DateTime.UtcNow,
              Guid.NewGuid()
            );


            return Ok(new Dictionary<string, object>
    {
      {"maxLength", maxLength},
      {"tweet", tweet },
    });
        }
    }
}
