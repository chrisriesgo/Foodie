using System;
using Xamarin.Forms;

namespace Foodie
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new TabbedPage 
				{
					Title = "Foodie",
					Children = 
					{
						new ListPage { Title = "Nearby" },
						new FavoritesPage { Title = "Favorites" }
					}
				}
			);
		}
	}
}

