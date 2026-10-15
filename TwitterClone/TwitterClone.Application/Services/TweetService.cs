using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces.Repository;
using TwitterClone.Application.Interfaces.Service;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;

        public TweetService(
            ITweetRepository tweetRepository,
            IUserRepository userRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }


        // GET TWEETS
        public List<TweetDto> GetTweets(Guid? userId)
        {
            List<Tweet> tweets;

            if (userId.HasValue)
            {
                tweets = _tweetRepository
                    .GetTweetsByUserId(userId.Value);
            }
            else
            {
                tweets = _tweetRepository.GetTweets();
            }

            return tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            }).ToList();
        }


        // GET TWEET BY ID
        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
        }


        // CREATE TWEET
        public TweetDto CreateTweet(CreateTweetRequest request)
        {
            // Validate content
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                throw new ArgumentException(
                    "Tweet content is required.");
            }

            // Check user
            var user = _userRepository
                .GetUserById(request.UserId);

            if (user == null)
            {
                throw new InvalidOperationException(
                    "User does not exist.");
            }

            // Create tweet
            var tweet = new Tweet(request.Content)
            {
                UserId = request.UserId
            };

            // Save
            _tweetRepository.AddTweet(tweet);

            // Return DTO
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
        }


        // UPDATE TWEET
        public TweetDto? UpdateTweet(
            Guid id,
            UpdateTweetRequest request)
        {
            // Validate content
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                throw new ArgumentException(
                    "Tweet content is required.");
            }

            // Find tweet
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            // Update
            tweet.Content = request.Content;

            _tweetRepository.UpdateTweet(tweet);

            // Return DTO
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content
            };
        }


        // DELETE TWEET
        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return false;
            }

            return _tweetRepository.DeleteTweet(tweet);
        }
    }
}
