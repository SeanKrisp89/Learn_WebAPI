using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Learn_WebAPI.Models
{
	public class PointOfInterestForCreationDto //We created this separate POI Data Transfer Object because our first one contains ID. The consumer of our API is not responsible for determining the Id, that's the data-persistence layer's responsibility (the Db).
	{
		[Required(ErrorMessage = "You must provide a name value.")]
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string Description { get; set; }

	}
}
