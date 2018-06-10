using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Domain;

namespace BusinessLogic.DTO
{
    public class SiteDTO
    {
        public int SiteId { get; set; }
        [Required]
        [MaxLength(4)]
        public string Name { get; set; }

        //automark
        [Required]
        [MaxLength(54)]
        public string AddressFirstLine { get; set; }

        //automudel
        [Required]
        [MaxLength(54)]
        public string Locality { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public List<PersonDTO> Persons { get; set; }

        public static SiteDTO CreateFromDomain(Site site)
        {
            return new SiteDTO
            {
                SiteId = site.SiteId,
                Name = site.Name,
                AddressFirstLine = site.AddressFirstLine,
                Locality = site.Locality,
                PostCode = site.PostCode,
                Country = site.Country,
                Description = site.Description
            };
        }

        public static SiteDTO CreateFromDomainWithSites(Site s)
        {
            var site = CreateFromDomain(s);
            if (site == null) return null;

            site.Persons = s?.Persons?
                .Select(PersonDTO.CreateFromDomain).ToList();
            return site;

        }
    }
}
