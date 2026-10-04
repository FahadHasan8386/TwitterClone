using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces.Service;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TweetsController : ControllerBase
{
    private readonly ITweetService _tweetService;

    public TweetsController(ITweetService tweetService)
    {
        _tweetService = tweetService;
    }


    // GET: api/tweets?userId={userId}
    [HttpGet]
    public IActionResult GetTweets([FromQuery] Guid? userId)
    {
        var tweets = _tweetService.GetTweets(userId);

        return Ok(tweets);
    }


    // GET: api/tweets/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetTweetById(
        [FromRoute] Guid id)
    {
        var tweet = _tweetService.GetTweetById(id);

        if (tweet == null)
        {
            return NotFound();
        }

        return Ok(tweet);
    }


    // POST: api/tweets
    [HttpPost]
    public IActionResult CreateTweet(
        [FromBody] CreateTweetRequest request)
    {
        try
        {
            var tweet = _tweetService.CreateTweet(request);

            return Ok(tweet);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    // PUT: api/tweets/{id}
    [HttpPut("{id:guid}")]
    public IActionResult UpdateTweet(
        [FromRoute] Guid id,
        [FromBody] UpdateTweetRequest request)
    {
        try
        {
            var tweet = _tweetService.UpdateTweet(id, request);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }


    // DELETE: api/tweets/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTweet(
        [FromRoute] Guid id)
    {
        var isDeleted = _tweetService.DeleteTweet(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
