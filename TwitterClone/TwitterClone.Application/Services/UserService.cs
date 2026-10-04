using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Repositories;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

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
                throw new InvalidOperationException(
                    "A user with that email already exists."
                );

            // Create entity
            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            // Save
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
    }
}
