using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities;

public class Retweet
{
    private Guid _userId;
    private Guid _tweetId;
    private DateTime _retweetAt;

    public Guid UserId
    {
        get { return _userId; }
    }

    public Guid TweetId
    {
        get { return _tweetId; }
    }

    public DateTime RetweetAt
    {
        get { return _retweetAt; }
    }
    public Retweet(Guid userId, Guid tweetId)
    {
        _userId = userId;
        _tweetId = tweetId;
        _retweetAt = DateTime.UtcNow;
    }
}
