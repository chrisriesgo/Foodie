using System;
using Xamarin.Forms;

namespace Foodie
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new ListPage ());
		}
	}
}

