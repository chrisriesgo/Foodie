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

			ToolbarItems.Add (new ToolbarItem () {
				Name = "reset",
				Command = new Command( () => _restaurantService.ResetFilter() )
			});

			var button1 = new Button () {
				Text = "Apply filter"
			};

			button1.Clicked += (sender, e) => {
				var filter = FilterSettings.DefaultFilter;
				filter.FoodStyle = "Mexican";
				_restaurantService.SetFilter (filter); 
			};

			var stacked = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			stacked.Children.Add (button1);

			Content = stacked;

//			MessagingCenter.Subscribe<IRestaurantService> (
//				this, 
//				"filter_updated",
//				x => { DisplayAlert("Filter updated", "Someone updated the filter ...", "ok", null); }
//			);

		}

//		protected override void OnDisappearing ()
//		{
//			base.OnDisappearing ();
//
//			MessagingCenter.Unsubscribe<IRestaurantService> (this, "filter_updated");
//		}
	}
}

