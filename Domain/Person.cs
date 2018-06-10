using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(45)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string IdCode { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public bool Active { get; set; } = true;

        //foreign keys
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        public int PersonRoleId { get; set; }
        public virtual PersonRole PersonRole { get; set; }
    }

}
