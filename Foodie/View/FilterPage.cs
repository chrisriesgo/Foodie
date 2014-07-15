using System;
using System.ComponentModel;
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

			var results = new Label () {
				Text = "",
				Font = Font.SystemFontOfSize (20),
				BindingContext = this
			};
			results.SetBinding (Label.TextProperty, "ResultText");

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

			stacked.Children.Add (results);
			stacked.Children.Add (button1);

			Content = stacked;

			MessagingCenter.Subscribe<IRestaurantService> (
				this, 
				"filter_updated",
				x => { 
					int matches = _restaurantService.GetNearByRestaurants().Count;
					ResultText = matches + " match" + (matches == 1 ? "" : "es");
				}
			);
		}

		string _resultText;
		public string ResultText
		{
			get
			{
				return _resultText;
			}
			set
			{
				_resultText = value;
				OnPropertyChanged();
			}
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			MessagingCenter.Unsubscribe<IRestaurantService> (this, "filter_updated");
		}
	}
}

