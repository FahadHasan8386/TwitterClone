using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(Guid id): base(id)
        {
        }

        public required string Name { get; set; }

    }
}
