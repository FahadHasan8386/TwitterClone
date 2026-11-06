using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Application.Dtos
{
    public class RegisterDto
    {
        [Required]
        [StringLength(50)]

        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]

        public required string LastName { get; set; }

        [Required]
        [EmailAddress]

        public required string Email { get; set; }

        [Required]
        [MinLength(8)]

        public required string Password { get; set; }
    }
}
