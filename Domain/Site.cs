using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    // Objekt (arhitektuuri mõistes) on Site inglise keeles
    public class Site
    {
        public int SiteId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Name { get; set; }

        //automark
        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string AddressFirstLine { get; set; }

        //automudel
        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Locality { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        // collections
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
