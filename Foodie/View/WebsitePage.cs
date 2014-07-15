using System;
using Xamarin.Forms;
using Foodie.Model;
using Foodie.Service;

namespace Foodie
{
	public class WebsitePage: ContentPage
	{
		Restaurant _restaurant;
		ToolbarItem _fav;

		public WebsitePage (Restaurant restaurant)
		{
			_restaurant = restaurant;

			Title = restaurant.Name;

			_fav = new ToolbarItem () {
				Name = "fav",
				Command = new Command (() => ToggleFavorite ()),
			};

			ToolbarItems.Add (_fav);

			Content = new WebView
			{
				Source = new UrlWebViewSource
				{
					Url = restaurant.WebsiteUrl,
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};
		}
			
		void ToggleFavorite ()
		{
			_restaurant.IsFavorite = !_restaurant.IsFavorite;

			// TODO: this doesn't seem to work :(
			_fav.Name = _restaurant.IsFavorite ? "unfav" : "fav";

			var service = DependencyService.Get<IRestaurantService> ();
			service.SetFavoriteRestaurant (_restaurant.Id, _restaurant.IsFavorite);
		}
	}
}

