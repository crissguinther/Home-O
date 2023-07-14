using Homeo.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homeo.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public int RentValue { get; set; }

        [Required]
        public PropertyTypeEnum PropertyType { get; set; }

        public User Owner { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
    }
}
