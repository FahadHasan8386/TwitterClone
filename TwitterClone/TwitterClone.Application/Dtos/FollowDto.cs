using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos;

public class FollowDto
{
    public required Guid Id { get; set; }
    public required Guid FollowerId { get; set; }
    public required Guid FollowingId { get; set; }
    public DateTime CreatedAt { get; set; }
}
