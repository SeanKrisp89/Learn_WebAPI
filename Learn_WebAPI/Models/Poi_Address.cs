using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_WebAPI.Models
{
	public class Poi_Address
	{
		public int Id { get; set; }
		public string Street { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int Postal { get; set; }
	}
}
