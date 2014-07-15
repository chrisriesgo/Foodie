using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Foodie.Service;

namespace Foodie
{
	public class FilterPage: ContentPage
	{
		IRestaurantService _restaurantService;
		FilterSettings _filter;
		List<string> _foodStyleOptions;

		public FilterPage ()
		{
			_restaurantService = DependencyService.Get<IRestaurantService> ();
			_filter = _restaurantService.GetFilter ();
			_foodStyleOptions = _restaurantService.GetFoodStyleFilterOptions ();

			Title = "Filter";

			ToolbarItems.Add (new ToolbarItem () {
				Name = "reset",
				Command = new Command( () => _restaurantService.ResetFilter() )
			});

			// RESULTS LABEL
			var results = new Label () {
				Text = "",
				Font = Font.SystemFontOfSize (30),
				HorizontalOptions = LayoutOptions.Center
			};
		
			// FOOD STYLE PICKER
			var foodStyleLabel = new Label () {
				Text = "Style"
			};

			var foodStyle = new Picker () {
				Title = "Food style",
				WidthRequest = 150,
				BindingContext = this,
			};
			foodStyle.Items.Add ("All");
			_foodStyleOptions.ForEach (x => foodStyle.Items.Add (x));
			foodStyle.SelectedIndexChanged += (sender, e) => {
				if (foodStyle.SelectedIndex == 0)
					_filter.FoodStyle = null;
				else
					_filter.FoodStyle = _foodStyleOptions [foodStyle.SelectedIndex-1];
				_restaurantService.SetFilter(_filter);
			};

			var foodStyleStack = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = { foodStyleLabel, foodStyle }
			};
				
			// MIN PRICE SLIDER
			var priceLabel = new Label () {
				Text = "Max Price"
			};

			var priceValue = new Label () {
				Text = _filter.MaxPrice.ToString()
			};

			var price = new Slider (1, 5, 3) {
				WidthRequest = 150,
				Value = _filter.MaxPrice
			};
			price.ValueChanged += (sender, e) => {
				if ( Math.Round(price.Value) != _filter.MaxPrice) 
				{
					_filter.MaxPrice = Convert.ToInt32(price.Value);
					priceValue.Text = _filter.MaxPrice.ToString();
					_restaurantService.SetFilter(_filter);
				}
			};
				
			var priceStack = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = { priceLabel, price, priceValue }
			};
			
			var stacked = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 30
			};

			stacked.Children.Add (results);
			stacked.Children.Add (foodStyleStack);
			stacked.Children.Add (priceStack);

			Content = stacked;

			MessagingCenter.Subscribe<IRestaurantService> (
				this, 
				"filter_updated",
				x => { 
					int matches = _restaurantService.GetNearByRestaurants().Count;
					results.Text = matches + " match" + (matches == 1 ? "" : "es");
				}
			);
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			MessagingCenter.Unsubscribe<IRestaurantService> (this, "filter_updated");
		}
	}
}

