using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.DTO;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/v1/cars")]
    public class CarsController : Controller
    {
        private readonly ISiteService _siteService;

        public CarsController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        // GET: api/v1/Sites
        [HttpGet]
        [ProducesResponseType(typeof(List<SiteDTO>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(429)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return Ok(_siteService.GetAllSites());
        }

        //// GET: api/cars/find
        //[HttpGet]
        //[Route("find")]
        //[ProducesResponseType(typeof(List<SiteDTO>), 200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(429)]
        //[ProducesResponseType(500)]
        //public IActionResult Find(string licensePlate, int personId)
        //{
        //    IEnumerable<SiteDTO> cars = new List<SiteDTO>();
        //    if (licensePlate != null)
        //    {
        //        cars = _siteService.FindCarsByLicensePlate(licensePlate);
        //    } else if (personId != 0)
        //    {
        //        cars = _siteService.FindCarsByPersonId(personId);
        //    }
        //    else
        //    {
        //        return Ok(_siteService.GetAllSites());
        //    }

        //    if (!cars.Any())
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cars);
        //}

        // GET: api/v1/Sites/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(SiteDTO), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(429)]
        [ProducesResponseType(500)]
        public IActionResult Get(int id)
        {
            var p = _siteService.GetSiteById(id);
            if (p == null) return NotFound();
            return Ok(p);
        }
        
        // POST: api/v1/Sites
        [HttpPost]
        [ProducesResponseType(typeof(SiteDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(429)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]SiteDTO site)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newCar = _siteService.AddNewSite(site);

            return CreatedAtAction("Get", new { id = newCar.SiteId }, newCar);
        }

        // PUT: api/v1/Sites/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(429)]
        [ProducesResponseType(500)]
        public IActionResult Put(int id, [FromBody]SiteDTO site)
        {
            if (!ModelState.IsValid) return BadRequest();
            var p = _siteService.GetSiteById(id);

            if (p == null) return NotFound();
            _siteService.UpdateSite(id, site);

            return NoContent();
        }

        /// <summary>
        /// Deletes a person by id.
        /// </summary>
        /// <param name="id">ID of person to delete</param>
        /// <response code="204">Person was successfully deleted, no content to be returned</response>
        /// <response code="404">Person not found by given ID</response>
        /// <response code="500">Internal error, unable to process request</response>
        // DELETE: api/v1/Sites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(int id)
        {
            var p = _siteService.GetSiteById(id);
            if (p == null) return NotFound();
            _siteService.DeleteSites(id);
            return NoContent();
        }
    }
}
