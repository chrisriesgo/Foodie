using System;
using Xamarin.Forms;

namespace Foodie
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage
			(
				new TabbedPage() 
				{
					Children = { 
						new ListPage { Title = "Nearby", Icon = "nearby.png" },
						new FavoritesPage { Title = "Favorites", Icon = "fav.png" }
					}
				}
			);
		}
	}
}

