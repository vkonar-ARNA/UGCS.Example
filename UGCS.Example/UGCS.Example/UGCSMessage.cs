using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANRA_WindowsClient
{
	public class UGCSMessage
	{
		public Guid enroute_positions_id { get; set; }
		public Altitude altitude_gps { get; set; }
		public int altitude_num_gps_satellites { get; set; }
		public Guid gufi { get; set; }
		public float hdop_gps { get; set; }
		public Point location { get; set; }
		public DateTime time_measured { get; set; }
		public DateTime time_received { get; set; }
		public DateTime time_sent { get; set; }
		public double track_bearing { get; set; }
		public string track_bearing_reference { get; set; } = "TRUE_NORTH";
		public string track_bearing_uom { get; set; } = "DEG";
		public double track_ground_speed { get; set; }
		public string track_ground_speed_units { get; set; } = "KT";
		public float vdop_gps { get; set; }
		public string user_id { get; set; }
		public float roll { get; set; }
		public float yaw { get; set; }
		public float pitch { get; set; }
		public float climbrate { get; set; }
		public int heading { get; set; }
		public int battery_remaining { get; set; }
		public string registration { get; set; }
		public string mode { get; set; }
		public Guid uss_instance_id { get; set; }

		public bool armed { get; set; }
		public bool landed { get; set; }
		public float battery_voltage { get; set; }
		public bool is_connected { get; set; }
		public string connection_error { get; set; }

		public override string ToString()
		{
			return $"Timestamp:{time_received} Lat: {location.coordinates[1]}  Lng: {location.coordinates[0]}  Alt: {altitude_gps.altitude_value}  Airspeed: {track_ground_speed}  Battery Remainng: {battery_remaining}";
		}
	}

	public class Point
	{
		public string type = "Point";
		public List<double?> coordinates { get; set; }
	}

	public class Altitude
	{
		public double altitude_value { get; set; }
		public string vertical_reference { get; set; } = "W84";
		public string units_of_measure { get; set; } = "FT";
		public string source { get; set; } = "ONBOARD_SENSOR";
	}

}
