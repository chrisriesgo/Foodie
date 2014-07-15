using System;
using Foodie.Model;

namespace Foodie.Service
{
	public class LocationServiceStubbed: ILocationService
	{
		public LocationServiceStubbed ()
		{
		}

		public GeoLocation GetCurrentLocation ()
		{
			// Firefly Logic's office
			return new GeoLocation () {
				Latitude = 36.177974,
				Longitude = -86.751071
			};
		}
	}
}

