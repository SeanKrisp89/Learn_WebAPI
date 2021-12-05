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

		[HttpGet("{id}", Name = "GetPointOfInterest")]//<-- so here we're only passing in point of interest Id in the HTTPGET attribute because the cityId will always be passed in since it was added in our Route template we added on the controller.
		//Additionally, the "Name" property is so that we can refer to it in helper methods like return CreatedAtRoute() - The reason it's on the get is because that's where they'd go to request this resource
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

		[HttpPost]
		public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
		//We want to make sure that this pointOfInterest is de-serialized from the request body; the API Controller attribute takes care of that. The PointOfInterestForCreationDto is considered a complex type and is assumed to be contained in the request body.
		//So to ensure that, we can decorate this method with the FromBody attribute above.
		//It is possible that the consumer of the API sends a bad request in such that the request body cannot be de-serialized into a POIFCDTO in which case our POIFCDTO will be null. Thus check for that!
		{
			//if(pointOfInterest == null) //So here, the consumer of our API f'ed up and sent over null for POIFCDTO. So we say "bad request buddy"
			//{
			//	return BadRequest();
			//}
			//HOWEVER - WE DON'T NEED TO WRITE THAT VALIDATION CHECK BECAUSE THE API CONTROLLER ATTRIBUTE AUTOMATICALLY CHECKS FOR THIS

			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if(city == null)
			{
				return NotFound();
			}

			//For demo only - shitty code to grab latest/new Id. 
			//So first grab the max existing PointOfInterest Id
			var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

			//Create new POI instance to store data from request body
			var finalPointOfInterest = new PointOfInterestDto()
			{
				Id = ++maxPointOfInterestId, //Increment the Id by 1
				Name = pointOfInterest.Name, //Set the name equal to that provided by the request body
				Description = pointOfInterest.Description //Set the description equal to that provided by the request body
			};

			city.PointsOfInterest.Add(finalPointOfInterest);

			//For POSTs, the recommended response from the server is a 201 Created response (as opposed to a 200 OK, this is more specific saying that the resource was actually created). SO this helper method returns just that
			return CreatedAtRoute("GetPointOfInterest", 
				new { cityId = cityId, id = finalPointOfInterest.Id },
				finalPointOfInterest);	//This allows us to return a response with a location header. That location header will contain the URI where the newly created POI (or resource) can be found. We still have to pass in any arguments required for the controller. So our cityId and PointOfInterestId passed into the method.
										//Technically we could just pass "cityId" by itself since our method parameter is also called cityId...
		}
	}
}
