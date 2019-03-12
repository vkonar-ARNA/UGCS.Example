using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
	public class UasRegistration
	{
		[JsonProperty(PropertyName = "registration_id")]
		public Guid? RegistrationId { get; set; }

		[JsonProperty(PropertyName = "registration_location")]
		public string RegistrationLocation { get; set; }
	}
}
