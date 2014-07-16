using System;
using Foodie.Model;
using Foodie.Service;

[assembly: Xamarin.Forms.Dependency (typeof (LocationServiceStubbed))]

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

