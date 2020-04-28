using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid EntityId { get; private set; }
        public EntityNotFoundException(Guid id) : base($"Entity with id {id} was not found")
        {
        }
    }
}

