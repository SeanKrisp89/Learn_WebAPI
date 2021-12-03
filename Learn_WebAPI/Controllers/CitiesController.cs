using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_WebAPI.Controllers
{
	[ApiController]
	public class CitiesController : ControllerBase //Controllerbase contains basic func controllers need like access to the modelstate, the current user, and common methods used for returning responses.
												   //We could also use Controller class, but that also supports views, and those are not needed when building APIs
	{
		//We want to return JSON as the format of our data representation...
		public JsonResult GetCities()
		{
			//JsonResult returns a Jsonified version of whatever we pass into the constructor of a new JsonResult object
			return new JsonResult(
				new List<object>()
				{
					new{id = 1, Name = "New York City"},
					new{id = 2, Name = "Antwerp"}
				});
		}
	}
}
