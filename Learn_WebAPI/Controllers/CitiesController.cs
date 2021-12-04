using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_WebAPI.Models;

namespace Learn_WebAPI.Controllers
{
	[ApiController]
	[Route("api/cities")]//This defines the route attribute for all methods in this controller. This is why the "(api/cities)" is commented out in the GetCities route attribute.
	public class CitiesController : ControllerBase //Controllerbase contains basic func controllers need like access to the modelstate, the current user, and common methods used for returning responses.
												   //We could also use Controller class, but that also supports views, and those are not needed when building APIs
	{
		//We want to return JSON as the format of our data representation...
		[HttpGet/*("api/cities")*/] // <-- this is "Attribute Routing"
		public JsonResult GetCities()
		{
			////JsonResult returns a Jsonified version of whatever we pass into the constructor of a new JsonResult object
			//return new JsonResult(
			//	new List<object>()
			//	{
			//		new{id = 1, Name = "New York City"},
			//		new{id = 2, Name = "Antwerp"}
			//	});

			return new JsonResult(CitiesDataStore.Current.Cities);
		}

		[HttpGet("{id}")] //Since again, we have the controller route ("api/cities") mapped up top at the controller level, we actually only need the {id} portion of the route attribute 
		public JsonResult GetCity(int id)
		{
			return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
		}


	}
}
