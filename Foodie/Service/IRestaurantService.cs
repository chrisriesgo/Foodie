using System;
using System.Collections.Generic;
using Foodie.Model;

namespace Foodie.Service
{
	public interface IRestaurantService
	{
		List<Restaurant> GetNearByRestaurants(double latitude, double longitude);
		List<Restaurant> GetFavoriteRestaurants();

		void SetFavoriteRestaurant(int id, bool isFavorite);

		void SetMaxPriceFilter (int maxPrice);
		void SetMinRatingFilter (int minPrice);
		void SetFoodStyleFilter (string foodStyle);

		void ResetFilter();

		List<int> GetPriceFilterOptions ();
		List<int> GetRatingFiltetOptions ();
		List<string> GetFoodStyleFiltetOptions ();
	}
}

