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
							Description = "The most visited urban park in the United States.",
							Address = new Poi_Address()
							{
								Id = 1,
								Street = "3n402 Bonnie Lane",
								City = "New York",
								State = "NY",
								Postal = 60175
							}
						},
						new PointOfInterestDto()
						{
							Id = 2,
							Name = "Empire State Building",
							Description = "The tallest building in the U.S. prior to the construction of the Sears Tower.",
							Address = new Poi_Address()
							{
								Id = 2,
								Street = "3n302 W Mary Lane",
								City = "New York",
								State = "NY",
								Postal = 60174
							}
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
							Description = "A Gothic style cathedral.",
							Address = new Poi_Address()
							{
								Id = 4,
								Street = "4E Mont du Roc",
								City = "Antwerp",
								State = "Some Belgium State",
								Postal = 44330
							}
						},
						new PointOfInterestDto()
						{
							Id = 4,
							Name = "Antwerp Central Station",
							Description = "The finest example of railway architecture in Belgium.",
							Address = new Poi_Address()
							{
								Id = 5,
								Street = "87P Mallein de Sre",
								City = "Antwerp",
								State = "Another Belgium State",
								Postal = 23994
							}
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
