using System;
using Xamarin.Forms;
using Foodie.Model;

namespace Foodie
{
	public class WebsitePage: ContentPage
	{
		public WebsitePage (Restaurant restaurant)
		{
			Title = restaurant.Name;

			Content = new WebView
			{
				Source = new UrlWebViewSource
				{
					Url = restaurant.WebsiteUrl,
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};
		}
	}
}

