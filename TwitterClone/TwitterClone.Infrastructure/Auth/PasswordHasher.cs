using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Interfaces.Auth;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    {
        public bool VerifyPassword(string password, string hashedPassword)
        {
            // business logic to verify password with hashed password.
            return true;
        }
    }
}
