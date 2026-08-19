using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Interface;

namespace TwitterClone.Domain.Entities;

public class User : BaseEntity , IFollowable , INotifiable
{

    private string _firstName;
    private string _lastName;
    private string _email;

    public User() : base(Guid.NewGuid())
    {

    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}";
    }

    private List<Guid> Followers = new List<Guid>();
    private List<Guid> Notifications = new List<Guid>();

    public void Follow(Guid userId)
    {
        if(!Followers.Contains(userId))
        {
            Followers.Add(userId);
        }
    }

    public void Unfollow(Guid userId)
    {
        if(Followers.Contains(userId))
        {
            Followers.Remove(userId);
        }
    }

    public void AddNotification(Guid notificationId)
    {
        if (!Notifications.Contains(notificationId)) 
        { 
            Notifications.Add(notificationId); 
        }
    }
}

