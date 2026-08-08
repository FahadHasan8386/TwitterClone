using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities;

public class Notification
{
    private Guid _id;
    private Guid _userId;
    private Guid _senderId;
    private string _type = string.Empty;
    private Guid? _tweetId;
    private bool _isRead;
    private DateTime _createdAt;

    public Guid Id
    {
        get { return _id; }
    }

    public Guid UserId
    {
        get { return _userId; }
    }

    public Guid SenderId
    {
        get { return _senderId; }
    }

    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public Guid? TweetId
    {
        get { return _tweetId; }
    }

    public bool IsRead
    {
        get { return _isRead; }
        set { _isRead = value; }
    }

    public DateTime CreatedAt
    {
        get { return _createdAt; }
    }
}
