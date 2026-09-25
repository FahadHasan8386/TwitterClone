using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Repository
{
    public class UserRepository
    {
        private readonly List<User> _users = new List<User>();

        public List<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            _users.RemoveAll(x => x.Id == user.Id);
            _users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            return _users.Remove(user);

        }

    }
}
