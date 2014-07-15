using System;
using System.Collections.Generic;
using Foodie.Model;

namespace Foodie.Service
{
	public class RestaurantServiceStub: IRestaurantService
	{
		public RestaurantServiceStub ()
		{
		}

		public List<Restaurant> GetNearByRestaurants ()
		{
			return new List<Restaurant> () {
				new Restaurant() {
					Id = 1,
					Name = "Pepperfire",
					Latitude = 36.201854,
					Longitude = -86.739916,
					ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/04/18/31/e1/pepperfire.jpg",
					WebsiteUrl = "http://pepperfirechicken.com/",
					Price = 1,
					Rating = 4,
					FoodStyle = "Hot Chicken",
					Distance = 1.5
				},
				new Restaurant() {
					Id = 2,
					Name = "Prince’s Hot Chicken Shack",
					Latitude = 36.201854,
					Longitude = -86.739916,
					ImageUrl = "http://www.hamburgercalculus.com/blog/wp-content/uploads/2009/01/princesfront.gif",
					WebsiteUrl = "http://www.yelp.com/biz/princes-hot-chicken-shack-nashville",
					Price = 1,
					Rating = 4,
					FoodStyle = "Hot Chicken",
					Distance = 5.4
				},
			};
		}

		public List<Restaurant> GetFavoriteRestaurants ()
		{
			return new List<Restaurant> () {
				new Restaurant() {
					Id = 1,
					Name = "Pepperfire",
					Latitude = 36.201854,
					Longitude = -86.739916,
					ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/04/18/31/e1/pepperfire.jpg",
					WebsiteUrl = "http://pepperfirechicken.com/",
					Price = 1,
					Rating = 4,
					FoodStyle = "Hot Chicken",
					Distance = 1.5
				},
			};
		}

		public void SetFavoriteRestaurant (int id, bool isFavorite)
		{
		}

		public void SetMaxPriceFilter (int maxPrice)
		{
		}

		public void SetMinRatingFilter (int minPrice)
		{
		}

		public void SetFoodStyleFilter (string foodStyle)
		{
		}

		public void ResetFilter ()
		{
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
			return new List<string> () { "Hot Chicken" };
		}
	}
}

