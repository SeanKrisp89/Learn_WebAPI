using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Learn_WebAPI.Controllers
{
	[ApiController]
	[Route("api/cities/{cityId}/pointsofinterest/{poiId}/poi_addresses/{id}")]
	public class Poi_AddressesController : ControllerBase
	{
		public IActionResult GetAddresses(int cityId, int poiId, int id)
		{
			//check to see first if the city and POI exists
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if(city == null)
			{
				return NotFound();
			}

			var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == poiId);

			if(poi == null)
			{
				return NotFound();
			}

			return Ok(poi.Address);
		}
	}
}
