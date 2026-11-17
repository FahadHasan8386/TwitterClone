using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Constants
{
    public class RoleNames
    {   
        public const string ClaimType = "role";

        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string User = "User";

    }

    public class  PermissionNames
    {

        public const string ClaimType = "permission";
        
        public const string UsersRead = "Users.Read";
        public const string UsersDelete = "Users.Delete";
        public const string RolesManage = "Roles.Manage";

        public static readonly string[] All = { UsersRead, UsersDelete, RolesManage };

    }
}
