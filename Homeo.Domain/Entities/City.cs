using System.ComponentModel.DataAnnotations;

namespace Homeo.Domain.Entities
{
    public class City
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [MaxLength(2)]
        public string StateAbbreviation { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
