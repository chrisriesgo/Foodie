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

			var webView = new WebView
			{
				Source = new UrlWebViewSource { Url = restaurant.WebsiteUrl },
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = webView;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			ToolbarItems.Add (new ToolbarItem () {
				Name = _restaurant.IsFavorite ? "Unfav" : "Fav",
				Command = new Command( () => ToggleFavorite() )
			});
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
		}
			
		// IsFavorite: true -> Unfav, false -> Fav
		void ToggleFavorite ()
		{
			_restaurant.IsFavorite = !_restaurant.IsFavorite;

			if (_restaurant.IsFavorite) 
			{
				ToolbarItems.RemoveAt (0);
				ToolbarItems.Add (new ToolbarItem 
					{
						Name = "Unfav",
						Command = new Command(() => ToggleFavorite())
					}
				);
			} 
			else 
			{
				ToolbarItems.RemoveAt (0);
				ToolbarItems.Add (new ToolbarItem 
					{
						Name = "Fav",
						Command = new Command(() => ToggleFavorite())
					}
				);
			}

			var service = DependencyService.Get<IRestaurantService> ();
			service.SetFavoriteRestaurant (_restaurant.Id, _restaurant.IsFavorite);
		}
	}
}

