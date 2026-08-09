using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities;

public class Follow
{
    private Guid _followerId;
    private Guid _followingId;
    private DateTime _followedAt;

    public Guid FollowerId
    {
        get { return _followerId; }
    }

    public Guid FollowingId
    {
        get { return _followingId; }
    }

    public DateTime FollowedAt
    {
        get { return _followedAt; }
    }
    public Follow(Guid followerId, Guid followingId)
    {
        _followerId = followerId;
        _followingId = followingId;
        _followedAt = DateTime.UtcNow;
    }
}
