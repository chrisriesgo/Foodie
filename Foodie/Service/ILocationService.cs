using System;
using Foodie.Model;

namespace Foodie.Service
{
	public interface ILocationService
	{
		GeoLocation GetCurrentLocation();
	}
}

