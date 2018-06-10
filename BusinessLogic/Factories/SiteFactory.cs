using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.DTO;
using Domain;

namespace BusinessLogic.Factories
{
    public interface ISiteFactory
    {
        SiteDTO Create(Site c);
        Site Create(SiteDTO dto);
    }
    public class SiteFactory : ISiteFactory
    {
        public SiteDTO Create(Site c)
        {
            return SiteDTO.CreateFromDomain(c);
        }

        public Site Create(SiteDTO dto)
        {
            return new Site
            {
                Name = dto.Name,
                AddressFirstLine = dto.AddressFirstLine,
                Locality = dto.Locality,
                PostCode = dto.PostCode,
                Country = dto.Country,
                Description = dto.Description
            };
        }
    }
}
