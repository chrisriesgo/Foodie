using System;
using Xamarin.Forms;

namespace Foodie
{
	public class ListPage: TabbedPage
	{
		public ListPage ()
		{
			Title = "Foodie";

			ToolbarItems.Add (new ToolbarItem () {
				Name = "filter",
				Command = new Command( () => 
					Navigation.PushAsync( new FilterPage() {

					})
				)
			});
		}
	}
}

