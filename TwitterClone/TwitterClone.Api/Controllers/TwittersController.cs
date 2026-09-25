using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Dtos;
using TwitterClone.Api.Repository;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TweetsController : ControllerBase
{
    private readonly TweetRepository _tweetRepository;
    private readonly UserRepository _userRepository;
    public TweetsController(TweetRepository tweetRepository, UserRepository userRepository)
    {
        _tweetRepository = tweetRepository;
        _userRepository = userRepository;
    }


    // GET /api/tweets?userId={userId}
    [HttpGet]
    public IActionResult GetTweets([FromQuery] Guid? userId)
    {
        List<Tweet> tweets;

        if (userId.HasValue)
        {
            tweets = _tweetRepository.GetTweetsByUserId(userId.Value);
        }
        else
        {
            tweets = _tweetRepository.GetTweets();
        }

        var tweetDtos = tweets.Select(tweet => new TweetDto
        {
            Id = tweet.Id,
            UserId = tweet.UserId,
            Content = tweet.Content
        });

        return Ok(tweetDtos);
    }

    // GET /api/tweets/{id}
    [HttpGet("{id}")]
    public IActionResult GetTweetById([FromRoute] Guid id)
    {
        var tweet = _tweetRepository.GetTweetById(id);

        if (tweet == null)
        {
            return NotFound();
        }

        var tweetDto = new TweetDto
        {
            Id = tweet.Id,
            UserId = tweet.UserId,
            Content = tweet.Content
        };

        return Ok(tweetDto);
    }

    // POST /api/tweets
    [HttpPost]
    public IActionResult CreateTweet([FromBody] CreateTweetRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Content))
        {
            return BadRequest("Tweet content is required.");
        }

        var user = _userRepository.GetUserById(request.UserId);

        if (user == null)
        {
            return BadRequest("User does not exist.");
        }

        var tweet = new Tweet(request.Content)
        {
            UserId = request.UserId
        };

        _tweetRepository.AddTweet(tweet);

        var tweetDto = new TweetDto
        {
            Id = tweet.Id,
            UserId = tweet.UserId,
            Content = tweet.Content
        };

        return Ok(tweetDto);
    }

    // PUT /api/tweets/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Content))
        {
            return BadRequest("Tweet content is required.");
        }

        var tweet = _tweetRepository.GetTweetById(id);

        if (tweet == null)
        {
            return NotFound();
        }

        tweet.Content = request.Content;

        _tweetRepository.UpdateTweet(tweet);

        var tweetDto = new TweetDto
        {
            Id = tweet.Id,
            UserId = tweet.UserId,
            Content = tweet.Content
        };

        return Ok(tweetDto);
    }

    // DELETE /api/tweets/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTweet([FromRoute] Guid id)
    {
        var tweet = _tweetRepository.GetTweetById(id);

        if (tweet == null)
        {
            return NotFound();
        }

        var isDeleted = _tweetRepository.DeleteTweet(tweet);

        return Ok(isDeleted);
    }

}
