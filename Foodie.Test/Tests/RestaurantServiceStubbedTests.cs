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

			Assert.AreEqual (3, list.Count);
		}

		[Test]
		public void GetNearByWithRatingFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			filter.MinRating = 4;
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (2, list.Count);
		}

		[Test]
		public void GetNearByWithPriceFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			filter.MaxPrice = 1;
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (2, list.Count);
		}

		[Test]
		public void GetNearByWithFoodStyleFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			filter.FoodStyle = "Mexican";
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (1, list.Count);
		}

		[Test]
		public void GetNearByWithDefaultFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			Assert.AreEqual (3, list.Count);
		}

		[Test]
		public void GetNearByAfterResetingFilterReturnsExpected()
		{
			IRestaurantService service = new RestaurantServiceStub ();

			var filter = FilterSettings.DefaultFilter;
			filter.FoodStyle = "Mexican";
			service.SetFilter (filter);

			var list = service.GetNearByRestaurants ();

			service.ResetFilter ();

			list = service.GetNearByRestaurants ();

			Assert.AreEqual (3, list.Count);
		}

	}
}

