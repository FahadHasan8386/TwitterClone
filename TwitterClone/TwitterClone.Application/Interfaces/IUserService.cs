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
        UserDto  CreateUser(CreateUserRequest createUserDto);
        UserDto GetUserById(Guid userId);
        UserDto UpdateUser(UpdateUserRequest updateUserDto);
        bool DeleteUser(Guid userId);
        List<UserDto> GetAllUsers();
    }
}
