using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces.Repository;
using TwitterClone.Application.Interfaces.Service;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // CREATE USER
        public UserDto CreateUser(CreateUserRequest request)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(request.FirstName))
                throw new ArgumentException("First name is required.");

            if (string.IsNullOrWhiteSpace(request.LastName))
                throw new ArgumentException("Last name is required.");

            if (string.IsNullOrWhiteSpace(request.Email))
                throw new ArgumentException("Email is required.");

            // Check duplicate email
            var existingUser = _userRepository.GetUserByEmail(request.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException(
                    "A user with that email already exists.");
            }

            // Create entity
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            // Save user
            _userRepository.CreateUser(newUser);

            // Return DTO
            return new UserDto
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email
            };
        }


        // GET ALL USERS
        public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetUsers();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            }).ToList();
        }


        // GET USER BY ID
        public UserDto? GetUserById(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }


        // UPDATE USER
        public UserDto? UpdateUser(Guid userId,UpdateUserRequest request)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
                return null;

            // Check duplicate email
            var existingEmailUser = _userRepository.GetUserByEmail(request.Email);

            if (existingEmailUser != null &&
                existingEmailUser.Id != userId)
            {
                throw new InvalidOperationException(
                    "A user with that email already exists.");
            }

            // Update entity
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            // Save changes
            _userRepository.UpdateUser(user);

            // Return DTO
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }


        // DELETE USER
        public bool DeleteUser(Guid userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
                return false;

            return _userRepository.DeleteUser(user);
        }
    }
}