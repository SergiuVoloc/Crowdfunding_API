using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crowdfunding_API.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public ICollection<User> UserId { get; set; } // figure out if it's not error to show at query creation
    }
}