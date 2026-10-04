using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces.Service
{
    public interface ITweetService
    {
        List<TweetDto> GetTweets(Guid? userId);

        TweetDto? GetTweetById(Guid id);

        TweetDto CreateTweet(CreateTweetRequest request);

        TweetDto? UpdateTweet(Guid id,UpdateTweetRequest request);

        bool DeleteTweet(Guid id);
    }
}
