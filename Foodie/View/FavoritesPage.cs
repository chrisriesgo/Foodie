using System;
using Xamarin.Forms;
using Foodie.Model;
using Foodie.Service;
using Foodie.View.Cell;

namespace Foodie
{
	public class FavoritesPage : ContentPage
	{
		public FavoritesPage ()
		{
			var service = DependencyService.Get<IRestaurantService>();
			BindingContext = this;

			BackgroundColor = Color.Silver;

			var listView = new ListView 
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				RowHeight = 250,
				InputTransparent = false,
				ItemsSource = service.GetFavoriteRestaurants (),
				ItemTemplate = new DataTemplate (typeof(PlaceCell))
			};

			listView.ItemTapped += (sender, e) => { 
				Navigation.PushAsync(new WebsitePage(e.Item as Restaurant));
				listView.SelectedItem = null;
			};

			this.Content = new StackLayout 
			{
				Children = { listView }
			};

			MessagingCenter.Subscribe<IRestaurantService> (
				this, 
				"favorites_updated",
				x => { listView.ItemsSource = service.GetFavoriteRestaurants(); }
			);
		}
	}
}

