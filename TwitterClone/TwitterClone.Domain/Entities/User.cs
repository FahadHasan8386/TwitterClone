using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities;

public class User
{
    private Guid _id;
    private string _firstName;
    private string _lastName;
    private string _email;

    public User(string firstName, string lastName, string email)
    {
        _id = Guid.NewGuid();
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
    }

    public Guid Id
    {
        get { return _id; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
}
