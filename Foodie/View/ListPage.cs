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

			Title = "East Nashville";

			ToolbarItems.Add (new ToolbarItem () {
				Name = "filter",
				Command = new Command( () => 
					Navigation.PushAsync( new FilterPage() {

					})
				)
			});

			BackgroundColor = Color.Silver;

			BindingContext = this;
			var listView = new ListView 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				RowHeight = 250,
				InputTransparent = false,
				ItemsSource = service.GetNearByRestaurants (0, 0),
				ItemTemplate = new DataTemplate (typeof(PlaceCell))
			};

			this.Content = new StackLayout 
			{
				Children = { listView }
			};
		}
	}
}

