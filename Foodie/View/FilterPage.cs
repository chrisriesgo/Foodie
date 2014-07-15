using System;
using Xamarin.Forms;
using Foodie.Service;

namespace Foodie
{
	public class FilterPage: ContentPage
	{
		IRestaurantService _restaurantService;

		public FilterPage ()
		{
			_restaurantService = DependencyService.Get<IRestaurantService> ();

			Title = "Filter";

//			ToolbarItems.Add (new ToolbarItem () {
//				Name = "fav",
//				Command = new Command( () => _restaurantService.ResetFilter() )
//			});
//
//			var button1 = new Button () {
//				Text = "Apply filter"
//			};
//
//			button1.Clicked += (sender, e) => {
//				_restaurantService.SetFilter( new FilterSettings() {
//					MinRating = 4,
//					MaxPrice = 3,
//					FoodStyle = null
//				});
//			};
//
//			var stacked = new StackLayout () {
//				HorizontalOptions = LayoutOptions.CenterAndExpand,
//				VerticalOptions = LayoutOptions.CenterAndExpand
//			};
//
//			stacked.Children.Add { button1 };
//
//			Content = stacked;
		}
	}
}

