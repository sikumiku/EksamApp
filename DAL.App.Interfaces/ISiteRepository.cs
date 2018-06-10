using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using Domain;

namespace DAL.App.Interfaces
{
    public interface ISiteRepository : IRepository<Site>
    {
        /// <summary>
        /// Check for entity existance by PK value
        /// </summary>
        /// <param name="id">Person PK value</param>
        /// <returns></returns>
        bool Exists(int id);

        //List<Site> FindByLicensePlate(string licensePlate);

        //List<Site> FindByPersonId(int personId);
    }
}
