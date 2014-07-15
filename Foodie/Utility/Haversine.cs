using System;

namespace Foodie.Utility
{
	public static class Haversine {

		public static double DistanceMi(double lat1, double lon1, double lat2, double lon2)
		{
			return DistanceKm(lat1, lon1, lat2, lon2) / 1.609344;
		}

		public static double DistanceKm(double lat1, double lon1, double lat2, double lon2)
		{
			var R = 6372.8; // Earth radius in Km
			var dLat = ToRadians(lat2 - lat1);
			var dLon = ToRadians(lon2 - lon1);
			lat1 = ToRadians(lat1);
			lat2 = ToRadians(lat2);
			
			var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
			var c = 2 * Math.Asin(Math.Sqrt(a));

			return R * c;
		}
		
		public static double ToRadians(double angle) {
			return Math.PI * angle / 180.0;
		}
	}
}