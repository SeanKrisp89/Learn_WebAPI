using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_WebAPI.Models
{
	public class PointOfInterestForCreationDto //We created this separate POI Data Transfer Object because our first one contains ID. The consumer of our API is not responsible for determining the Id, that's the data-persistence layer's responsibility (the Db).
	{
		public string Name { get; set; }
		public string Description { get; set; }

	}
}
