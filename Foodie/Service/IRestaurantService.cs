using System;
using System.Collections.Generic;
using Foodie.Model;

namespace Foodie.Service
{
	public interface IRestaurantService
	{
		List<Restaurant> GetNearByRestaurants();
		List<Restaurant> GetFavoriteRestaurants();

		void SetFavoriteRestaurant(int id, bool isFavorite);

		void SetFilter(FilterSettings filter);
		void ResetFilter();

		List<int> GetPriceFilterOptions ();
		List<int> GetRatingFilterOptions ();
		List<string> GetFoodStyleFilterOptions ();
	}
}
