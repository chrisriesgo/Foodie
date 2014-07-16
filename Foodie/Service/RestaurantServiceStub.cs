using System;
using System.Collections.Generic;
using Foodie.Model;
using System.Linq;
using Xamarin.Forms;
using Foodie.Utility;
using Foodie.Service;

[assembly: Xamarin.Forms.Dependency (typeof (RestaurantServiceStub))]

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
			},
			new Restaurant () {
				Id = 4,
				Name = "Far East",
				Latitude = 36.174147,
				Longitude = -86.751058,
				ImageUrl = "http://nashvilleguru.com/officialwebsite/wp-content/uploads/2011/07/East-Nashville-TN-15-480x320-1392490754.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/far-east-nashville-nashville?osq=Far+East",
				Price = 2,
				Rating = 4,
				FoodStyle = "Thai",
				Distance = 0.4,
				IsFavorite = false
			},
			new Restaurant () {
				Id = 5,
				Name = "Mas Tacos",
				Latitude = 36.184770,
				Longitude = -86.754666,
				ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/03/1d/89/4f/mas-tacos.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/mas-tacos-nashville",
				Price = 1,
				Rating = 5,
				FoodStyle = "Mexican",
				Distance = 0.8,
				IsFavorite = true
			},
			new Restaurant () {
				Id = 6,
				Name = "Bongo Java",
				Latitude = 36.177035,
				Longitude = -86.749639,
				ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/01/79/b6/ff/bongo-java-where-coffee.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/bongo-java-east-nashville",
				Price = 1,
				Rating = 3,
				FoodStyle = "Coffee House",
				Distance = 0.2,
				IsFavorite = false
			},
			new Restaurant () {
				Id = 7,
				Name = "Battr'd & Fried",
				Latitude = 36.176965,
				Longitude = -86.750829,
				ImageUrl = "http://www.batteredandfried.com/uploaded/gallery/big/photo_01.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/batterd-and-fried-boston-seafood-house-nashville",
				Price = 2,
				Rating = 3,
				FoodStyle = "Pub",
				Distance = 0.1,
				IsFavorite = false
			},
			new Restaurant () {
				Id = 8,
				Name = "The Pharmacy",
				Latitude = 36.184936,
				Longitude = -86.754206,
				ImageUrl = "http://whocookedthisish.files.wordpress.com/2012/10/pharmacy.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/the-pharmacy-burger-parlor-and-beer-garden-nashville",
				Price = 2,
				Rating = 4,
				FoodStyle = "American",
				Distance = 0.8,
				IsFavorite = true
			},
			new Restaurant () {
				Id = 9,
				Name = "Sky Blue Cafe",
				Latitude = 36.171367,
				Longitude = -86.758867,
				ImageUrl = "http://www.nashvillelifestyles.com/_scripts/img_pp_crop.php?w=632&h=475&img=/_uploads/articles/BlueSky.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/sky-blue-cafe-nashville",
				Price = 1,
				Rating = 4,
				FoodStyle = "Coffee House",
				Distance = 0.7,
				IsFavorite = false
			},
			new Restaurant () {
				Id = 10,
				Name = "Fat Bottom Brewery",
				Latitude = 36.175879,
				Longitude = -86.757046,
				ImageUrl = "http://www.nashvillescene.com/binary/8d27/1326835076-fatbottomrendering.jpg",
				WebsiteUrl = "http://www.yelp.com/biz/fat-bottom-brewing-nashville?osq=fat+bottom+brewery",
				Price = 2,
				Rating = 4,
				FoodStyle = "Pub",
				Distance = 0.4,
				IsFavorite = false
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

		public FilterSettings GetFilter ()
		{
			return _filter;
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
			return new List<string> () 
			{ 
				"American",
				"Coffee House",
				"Hot Chicken", 
				"Mexican",
				"Pub",
				"Thai"
			};
		}
	}
}

