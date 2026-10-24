using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos;

public class LikeDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid TweetId { get; set; }
    public DateTime CreatedAt { get; set; }
}
