using System;
using System.Collections.Generic;
using Foodie.Model;
using System.Linq;
using Xamarin.Forms;
using Foodie.Utility;

namespace Foodie.Service
{
	public class RestaurantServiceStub: IRestaurantService
	{
		ILocationService _locationService;

		static FilterSettings _filter = FilterSettings.DefaultFilter;

		static List<Restaurant> _masterList = new List<Restaurant> () {
			new Restaurant () {
				Id = 1,
				Name = "Pepperfire",
				Latitude = 36.201854,
				Longitude = -86.739916,
				ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/04/18/31/e1/pepperfire.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/pepperfire-nashville",
				Price = 1,
				Rating = 4,
				FoodStyle = "Hot Chicken",
				Distance = 1.5,
				IsFavorite = true
			},
			new Restaurant () {
				Id = 2,
				Name = "Prince’s Hot Chicken Shack",
				Latitude = 36.230029,
				Longitude = -86.761071,
				ImageUrl = "http://www.hamburgercalculus.com/blog/wp-content/uploads/2009/01/princesfront.gif",
				WebsiteUrl = "http://www.yelp.com/biz/princes-hot-chicken-shack-nashville",
				Price = 1,
				Rating = 3,
				FoodStyle = "Hot Chicken",
				Distance = 5.4,
				IsFavorite = false
			},
			new Restaurant () {
				Id = 3,
				Name = "Five Points Cocina Mexicana",
				Latitude = 36.177633,
				Longitude = -86.752100,
				ImageUrl = "https://www.springrewards.com/dyn_assets/images/merchants/fivepointscocina/img.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/five-points-cocina-mexicana-nashville",
				Price = 2,
				Rating = 4,
				FoodStyle = "Mexican",
				Distance = 0.2,
				IsFavorite = true
			}
		};

		public RestaurantServiceStub ()
		{
			_locationService = DependencyService.Get<ILocationService> ();
		}

		List<Restaurant> MasterList
		{
			get { return _masterList; }
		}

		public List<Restaurant> GetNearByRestaurants ()
		{
			var filtered = MasterList.Where(x => 
				x.Rating >= _filter.MinRating &&
				x.Price <= _filter.MaxPrice &&
				(_filter.FoodStyle != null ? x.FoodStyle == _filter.FoodStyle : true)
			).ToList();

			return SetDistanceAndSort (filtered);
		}

		public List<Restaurant> GetFavoriteRestaurants ()
		{
			var filtered = MasterList.Where(x => x.IsFavorite).ToList();

			return SetDistanceAndSort (filtered);
		}

		List<Restaurant> SetDistanceAndSort(List<Restaurant> r)
		{
			GeoLocation loc = _locationService.GetCurrentLocation ();

			r.ForEach (x => x.Distance = Math.Round( Haversine.DistanceMi (x.Latitude, x.Longitude, loc.Latitude, loc.Longitude), 1));

			return r.OrderBy (x => x.Distance).ToList();
		}

		public void SetFavoriteRestaurant (int id, bool isFavorite)
		{
			var r = MasterList.First (x => x.Id == id);
			r.IsFavorite = isFavorite;

			MessagingCenter.Send<IRestaurantService> (this, "favorites_updated");
		}

		public void SetFilter (FilterSettings filter)
		{
			_filter = filter;

			SendFilterUpdatedMessage ();
		}

		public void ResetFilter ()
		{
			_filter = FilterSettings.DefaultFilter;

			SendFilterUpdatedMessage ();
		}

		void SendFilterUpdatedMessage()
		{
			MessagingCenter.Send<IRestaurantService> (this, "filter_updated");
		}

		public System.Collections.Generic.List<int> GetPriceFilterOptions ()
		{
			return new List<int> { 1, 2, 3 };
		}

		public System.Collections.Generic.List<int> GetRatingFilterOptions ()
		{
			return new List<int> { 1, 2, 3, 4, 5 };
		}

		public System.Collections.Generic.List<string> GetFoodStyleFilterOptions ()
		{
			return new List<string> () { "Hot Chicken", "Mexican" };
		}
	}
}

