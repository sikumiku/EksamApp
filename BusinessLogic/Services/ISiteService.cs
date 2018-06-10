using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.DTO;

namespace BusinessLogic.Services
{
    public interface ISiteService
    {
        IEnumerable<SiteDTO> GetAllSites();

        SiteDTO GetSiteById(int id);

        //IEnumerable<SiteDTO> FindCarsByLicensePlate(string licensePlate);

        //IEnumerable<SiteDTO> FindCarsByPersonId(int personId);

        SiteDTO AddNewSite(SiteDTO dto);

        void UpdateSite(int id, SiteDTO dto);

        void DeleteSites(int id);
    }
}
