using System;
using Newtonsoft.Json;

namespace Services.DTO
{
	public class UssInstanceLookupItem
	{
		[JsonProperty(PropertyName = "uss_instance_id")]
		public Guid UssInstanceId { get; set; }

		[JsonProperty(PropertyName = "uss_name")]
		public string UssName { get; set; }

		[JsonProperty(PropertyName = "is_anra_uss_instance")]
		public bool IsAnraUssInstance { get; set; }

		public string Name { get { return $"{UssName} - {UssInstanceId}"; } }
	}
}
