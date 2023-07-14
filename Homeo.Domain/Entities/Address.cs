using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homeo.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string ZipCode { get; set; }
        
        public City City { get; set; }
        
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
    }
}
