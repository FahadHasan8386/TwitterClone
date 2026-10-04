using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces.Repository;

public interface IUserRepository
{
    List<User> GetUsers();
    User? GetUserById(Guid id);
    User CreateUser(User user);
    User? GetUserByEmail(string email);
    User UpdateUser(User user);
    bool DeleteUser(User user);
}
