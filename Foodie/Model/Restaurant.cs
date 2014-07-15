using System;

namespace Foodie.Model
{
	public class Restaurant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string FoodStyle { get; set; }
		public int Rating { get; set; }
		public int Price { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string ImageUrl { get; set; }
		public string WebsiteUrl { get; set; }

		// denormalized
		public bool IsFavorite { get; set; }
		public double Distance { get; set; }
	}
}

