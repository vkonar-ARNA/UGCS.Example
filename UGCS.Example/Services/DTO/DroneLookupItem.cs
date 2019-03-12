using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
	public class DroneLookupItem
	{
			public int DroneId { get; set; }
			public string Uid { get; set; }
			public string IpAddress { get; set; }
			public int UpdPort { get; set; }
			public string Name { get; set; }
			public string BaseLng { get; set; }
			public string BaseLat { get; set; }
			public string BaseAlt { get; set; }
			public int? BrandId { get; set; }
			public string BrandName { get; set; }
			public bool IsRadarEnabled { get; set; }
	
	}
}
