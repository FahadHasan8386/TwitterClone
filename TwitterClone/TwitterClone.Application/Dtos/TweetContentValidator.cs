using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Dtos
{
    // Tweet.MaxContentLength is not a constant, so it can't be used in a [StringLength] attribute.
    internal static class TweetContentValidator
    {
        public static IEnumerable<ValidationResult> Validate(string content, string memberName)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                yield return new ValidationResult("Tweet content cannot be empty.", new[] { memberName });
            }
            else if (content.Length > Tweet.MaxContentLength)
            {
                yield return new ValidationResult(
                    $"Tweet content cannot be longer than {Tweet.MaxContentLength} characters.",
                    new[] { memberName });
            }
        }
    }
}
