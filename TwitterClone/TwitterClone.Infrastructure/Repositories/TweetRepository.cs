using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Interfaces.Repository;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly List<Tweet> _tweets = new();

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweets
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(x => x.Id == id);
        }

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);

            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            var existingTweet = GetTweetById(tweet.Id);

            if (existingTweet == null)
            {
                return tweet;
            }

            existingTweet.Content = tweet.Content;

            return existingTweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }
    }
}
