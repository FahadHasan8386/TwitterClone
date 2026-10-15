using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces.Repository;

public interface ITweetRepository
{
    List<Tweet> GetTweets();

    List<Tweet> GetTweetsByUserId(Guid userId);

    Tweet? GetTweetById(Guid id);

    Tweet AddTweet(Tweet tweet);

    Tweet UpdateTweet(Tweet tweet);

    bool DeleteTweet(Tweet tweet);
}
