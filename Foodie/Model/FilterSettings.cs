using System;

namespace Foodie
{
	public class FilterSettings
	{
		public int MaxPrice { get; set; }
		public int MinRating { get; set; }
		public string FoodStyle { get; set; }

		public static FilterSettings DefaultFilter
		{
			get 
			{ 
				return new FilterSettings () {
					MaxPrice = 3,
					MinRating = 1,
					FoodStyle = null
				};
			}
		}
	}
}

