using System;
using Xamarin.Forms;

namespace Foodie.View.Cell
{
	public class PlaceCell : ViewCell
	{
		public PlaceCell ()
		{
			// create the layout for the Picture Cell
			var relativeLayout = new RelativeLayout 
			{
				BackgroundColor = Color.Black
			};

			/* create the UI elements in the Picture Cell */
			// create picture 
			var pic = new Image
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			// create creator label 
			var nameLabel = new Label 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.White,
				Font = Font.BoldSystemFontOfSize(16)
			};

			pic.SetBinding (Image.SourceProperty, "ImageUrl");
			nameLabel.SetBinding (Label.TextProperty, "Name");

			// add children to relativeLayout
			relativeLayout.Children.Add (pic, 
				Constraint.Constant (0), 
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => { return parent.Width; }),
				Constraint.RelativeToParent ((parent) => { return parent.Height; })
			);

			var stackLayout = new StackLayout 
			{
				BackgroundColor = Color.FromRgba(0, 0, 0, 150),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(5, 0, 5, 0),
				Children = 
				{
					(Label)nameLabel,
				}
			};

			relativeLayout.Children.Add (stackLayout, 
				Constraint.Constant(0),
				Constraint.RelativeToView(pic, (parent,sibling) => { return sibling.Height - 40; }),
				Constraint.RelativeToView(pic, (parent,sibling) => { return sibling.Width;}),
				Constraint.Constant(30)
			);

			this.View = relativeLayout;
		}
	}
}

