using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Interface;

public interface IFollowable
{
    void Follow(Guid userId);
    void Unfollow(Guid userId);
}
