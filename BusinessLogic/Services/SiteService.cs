using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.DTO;
using BusinessLogic.Factories;
using DAL.App.Interfaces;
using Domain;

namespace BusinessLogic.Services
{
    public class SiteService : ISiteService
    {

        private readonly IAppUnitOfWork _uow;
        private readonly ISiteFactory _siteFactory;

        public SiteService(IAppUnitOfWork uow, ISiteFactory siteFactory)
        {
            _uow = uow;
            _siteFactory = siteFactory;
        }
        public IEnumerable<SiteDTO> GetAllSites()
        {
            return _uow.Sites.All()
                .Select(site => _siteFactory.Create(site));
        }

        public SiteDTO GetSiteById(int id)
        {
            var site = _uow.Sites.Find(id);
            if (site == null) return null;

            return _siteFactory.Create(site);
        }

        //public IEnumerable<SiteDTO> FindCarsByLicensePlate(string licensePlate)
        //{
        //    if (String.IsNullOrEmpty(licensePlate)) return null;

        //    return _uow.Sites.All().Where(x => x.LicensePlate.Contains(licensePlate))
        //        .Select(car => _siteFactory.Create(car)).ToList();
        //}

        //public IEnumerable<SiteDTO> FindCarsByPersonId(int personId)
        //{
        //    return _uow.Sites.All().Where(x => x.PersonId == personId)
        //        .Select(car => _siteFactory.Create(car)).ToList();
        //}

        //public List<SiteDTO> FindCars(string licensePlate, int personId)
        //{
        //    List<Site> cars = new List<Site>();
        //    if (licensePlate != null)
        //    {
        //        cars = _uow.Sites.FindByLicensePlate(licensePlate);
        //    } else if (personId != 0)
        //    {
        //        cars = _uow.Sites.FindByPersonId(personId);
        //    }
            
        //    if (cars == null  || cars.Count == 0) return null;

        //    var carCollection = new List<SiteDTO>();

        //    foreach (var car in cars)
        //    {
        //        carCollection.Add(_siteFactory.Create(car));
        //    }

        //    return carCollection;
        //}

        public SiteDTO AddNewSite(SiteDTO dto)
        {
            var newSite = _siteFactory.Create(dto);
            _uow.Sites.Add(newSite);
            _uow.SaveChanges();
            return _siteFactory.Create(newSite);
        }

        public void UpdateSite(int id, SiteDTO dto)
        {
            Site site = _uow.Sites.Find(id);
            site.Name = dto.Name;
            site.AddressFirstLine = dto.AddressFirstLine;
            site.Locality = dto.Locality;
            site.PostCode = dto.PostCode;
            site.Country = dto.Country;
            site.Description = dto.Description;
            _uow.Sites.Update(site);
            _uow.SaveChanges();
        }

        public void DeleteSites(int id)
        {
            Site site = _uow.Sites.Find(id);
            _uow.Sites.Remove(site);
            _uow.SaveChanges();
        }
    }
}
