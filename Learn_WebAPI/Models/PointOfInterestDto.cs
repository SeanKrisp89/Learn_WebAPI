using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_WebAPI.Models;

namespace Learn_WebAPI.Models
{
	public class PointOfInterestDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Poi_Address Address { get; set; }
	}
}
