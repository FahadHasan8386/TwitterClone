using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos;

public class CreateFollowDto
{
    public required Guid FollowerId { get; set; }
    public required Guid FollowingId { get; set; }
}
