using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Classes;

namespace Services.DTO
{
	public class AnraUdpPacket
	{
		public AnraUdpPacket(string token)
		{
			Token = token;
			DataType = "Telemetry";
		}

		public string Token { get; private set; }
		public string DataType { get; private set; }
		public string Data { get; set; }
	}
}
