using System.ComponentModel.DataAnnotations;

namespace Crowdfunding_API.Entities
{
    public class Role
    {
        public int ID { get; set; }

        [Required]
        public string Value { get; set; }
    }
}