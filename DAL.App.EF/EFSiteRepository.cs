using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.App.Interfaces;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class EFSiteRepository : EFRepository<Site>, ISiteRepository
    {
        public EFSiteRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public bool Exists(int id)
        {
            return RepositoryDbSet.Any(e => e.SiteId == id);
        }

        //public List<Site> FindByLicensePlate(string licensePlate)
        //{
        //    return RepositoryDbSet.Where(e => e.LicensePlate == licensePlate).ToList();
        //}


        //public List<Site> FindByPersonId(int personId)
        //{
        //    return RepositoryDbSet.Where(e => e.PersonId == personId).ToList();
        //}
    }
}
