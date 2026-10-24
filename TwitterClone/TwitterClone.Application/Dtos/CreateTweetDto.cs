using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos
{
    public class CreateTweetDto : IValidatableObject
    {
        public required Guid UserId { get; set; }

        [Required]
        public required string Content { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return TweetContentValidator.Validate(Content, nameof(Content));
        }
    }
}
