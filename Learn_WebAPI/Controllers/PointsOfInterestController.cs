using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_WebAPI.Models;

namespace Learn_WebAPI.Controllers
{
	[ApiController]
	//[Route("api/pointsofinterest")] <-- so technically speaking, this is valid, but conceptually it doesn't make sense. A point of interest by itself doesn't quite make sense outside the context of a city. So...
	[Route("api/cities/{cityId}/pointsofinterest")]
	public class PointsOfInterestController : ControllerBase //See lesson "Returning Child Resources". Basically what this means is that we may at times want to return PROPERTIES of a given resource (which obviously can be of another type/class/resource/entity itself). So I guess we need to build a controller for each child resource we want to return???
	{
		[HttpGet]
		public IActionResult GetPointsOfInterest(int cityId) //the cityId parameter is automatically inferred from the route template we provided in the route attribute.
		{
			//Since city is a parent resource/entity, we should first check to see if that exists.
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if(city == null)
			{
				return NotFound();
			}

			return Ok(city.PointsOfInterest);
		}

		[HttpGet("{id}")]//<-- so here we're only passing in point of interest Id in the HTTPGET attribute because the cityId will always be passed in since it was added in our Route template we added on the controller.
		public IActionResult GetPointOfInterest(int cityId, int id)
		{
			//Check for city first
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if(city == null)
			{
				return NotFound();
			}

			//Find point of interest

			var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

			if(pointOfInterest == null)
			{
				return NotFound();
			}

			return Ok(pointOfInterest);
		}
	}
}
