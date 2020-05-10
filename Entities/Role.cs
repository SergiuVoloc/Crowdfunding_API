using System.ComponentModel.DataAnnotations;

namespace Crowdfunding_API.Entities
{
    public class Role
    {
        public int ID { get; set; }

        [Required]
        public int Value { get; set; }
    }
}