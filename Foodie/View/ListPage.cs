using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Foodie.Model;
using Foodie.Service;
using Foodie.View.Cell;

namespace Foodie
{
	public class ListPage: ContentPage
	{
		public ListPage ()
		{
			var service = DependencyService.Get<IRestaurantService>();

			BackgroundColor = Color.Silver;

			ToolbarItems.Add (new ToolbarItem () {
				Name = "Filter",
				#if __IOS__
				Icon = "filter.png",
				#endif
				Command = new Command( () => 
					Navigation.PushAsync( new FilterPage() {

					})
				)
			});

			BindingContext = this;
			var listView = new ListView 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				RowHeight = 250,
				InputTransparent = false,
				ItemsSource = service.GetNearByRestaurants (),
				ItemTemplate = new DataTemplate (typeof(PlaceCell))
			};
					
			listView.ItemTapped += (sender, e) => 
			{ 
				Navigation.PushAsync(new WebsitePage(e.Item as Restaurant));
				listView.SelectedItem = null;
			};

			this.Content = new StackLayout 
			{
				Children = { listView }
			};

			MessagingCenter.Subscribe<IRestaurantService> (
				this, 
				"filter_updated",
				x => { listView.ItemsSource = service.GetNearByRestaurants(); }
			);
		}
	}
}

