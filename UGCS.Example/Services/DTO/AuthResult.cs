

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
	public class AuthResult
	{
		public bool IsAuthenticated { get; set; }
		public string UserId { get; set; }
		public string Token { get; set; }
		public DateTime? TokenExpires { get; set; }
		public string UserName { get; set; }
		public string Roles { get; set; }
		public string MassUnit { get; set; }
		public string LengthUnit { get; set; }
		public string TemperatureUnit { get; set; }
		public string ProfilePhoto { get; set; }
		public string UserEmail { get; set; }
	}
}
