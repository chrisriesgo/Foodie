using System;
using NUnit.Framework;
using Foodie.Service;

namespace Foodie.Test
{
	[TestFixture]
	public class RestaurantServiceStubbedTests
	{
		public RestaurantServiceStubbedTests ()
		{
		}

		[Test]
		public void GetFavoritesReturnsOnlyFavoritePlaces()
		{
			IRestaurantService service = new RestaurantServiceStub ();
			var list = service.GetFavoriteRestaurants ();

			list.ForEach (x => Assert.IsTrue (x.IsFavorite));
		}

		[Test]
		public void GetNearByWithNoFilterReturnsAll()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			service.ResetFilter ();

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (2, list.Count);
		}

		[Test]
		public void GetNearByWithFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			filter.MinRating = 4;
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (1, list.Count);
		}
	}
}

