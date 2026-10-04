using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto CreateUser(CreateUserRequest request);

        UserDto? GetUserById(Guid userId);

        List<UserDto> GetAllUsers();

        UserDto? UpdateUser(Guid userId, UpdateUserRequest request);

        bool DeleteUser(Guid userId);
    }
}