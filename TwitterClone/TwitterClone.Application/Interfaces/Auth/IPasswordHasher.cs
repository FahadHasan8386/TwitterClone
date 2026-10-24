using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string password, string hashedPassword);
    }
}
