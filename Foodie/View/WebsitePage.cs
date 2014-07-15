using System;
using Xamarin.Forms;
using Foodie.Model;
using Foodie.Service;

namespace Foodie
{
	public class WebsitePage: ContentPage
	{
		Restaurant _restaurant;

		public WebsitePage (Restaurant restaurant)
		{
			_restaurant = restaurant;

			Title = restaurant.Name;

			ToolbarItems.Add (new ToolbarItem () {
				Name = "fav",
				Command = new Command( () => ToggleFavorite() )
			});

			var webView = new WebView
			{
				Source = new UrlWebViewSource { Url = restaurant.WebsiteUrl },
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = webView;
		}
			
		void ToggleFavorite ()
		{
			_restaurant.IsFavorite = !_restaurant.IsFavorite;

			var service = DependencyService.Get<IRestaurantService> ();
			service.SetFavoriteRestaurant (_restaurant.Id, _restaurant.IsFavorite);
		}
	}
}

