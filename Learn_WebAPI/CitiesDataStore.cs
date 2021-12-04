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
					Description = "The one with the big park.",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
						new PointOfInterestDto()
						{
							Id = 1,
							Name = "Central Park",
							Description = "The most visited urban park in the United States."
						},
						new PointOfInterestDto()
						{
							Id = 2,
							Name = "Central Park",
							Description = "The most visited urban park in the United States."
						}
					}
				},
				new CityDto()
				{
					Id = 2,
					Name = "Antwerp",
					Description = "The one with the cathedral that was never really finished.",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
						new PointOfInterestDto()
						{
							Id = 3,
							Name = "Cathedral of Our Lady",
							Description = "A Gothic style cathedral."
						},
						new PointOfInterestDto()
						{
							Id = 4,
							Name = "Antwerp Central Station",
							Description = "The finest example of railway architecture in Belgium."
						}
					}
				},
				new CityDto()
				{
					Id = 3,
					Name = "Paris",
					Description = "The one with that big tower.",
					PointsOfInterest = new List<PointOfInterestDto>()
					{
						new PointOfInterestDto()
						{
							Id = 5,
							Name = "Eiffel Tower",
							Description = "The pointy thang."
						},
						new PointOfInterestDto()
						{
							Id = 6,
							Name = "The Louvre",
							Description = "Artsy French museum."
						}
					}
				}
			};
		}
	}
}
