using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_WebAPI.Models;

namespace Learn_WebAPI
{
	public class CitiesDataStore
	{
		public static CitiesDataStore Current { get; } = new CitiesDataStore();//static property that makes sure we can keep working on the same instance so long as we don't restart the web server
		public List<CityDto> Cities { get; set; }

		public CitiesDataStore()//This is our "In-Memory Data Store"
		{
			Cities = new List<CityDto>()
			{
				new CityDto()
				{
					Id = 1,
					Name = "New York City",
					Description = "The one with the big park."
				},
				new CityDto()
				{
					Id = 2,
					Name = "Antwerp",
					Description = "The one with the cathedral that was never really finished."
				},
				new CityDto()
				{
					Id = 3,
					Name = "Paris",
					Description = "The one with that big tower."
				}
			};
		}
	}
}
