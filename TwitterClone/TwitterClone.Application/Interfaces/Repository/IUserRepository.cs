using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces.Repository;

public interface IUserRepository
{
    User AddUser(User user);
    User UpdateUser(User user);
    bool DeleteUser(User user);
    User? GetUserById(Guid id);
    List<User> GetUsers();
    User? GetUserByEmail(string email);
}
