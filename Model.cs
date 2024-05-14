namespace Ecom_GoruKhasi
{
	public class Model
	{
        public class User
        {
            public string? UserID { get; set; }
            public string? FullName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Password { get; set; }
            public string? District { get; set; }
            public string? Area { get; set; }
            public string? Email { get; set; }

        }

        public class Admin
        {
            public string? AdminID { get; set; }
            public string? FullName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Password { get; set; }
            public string? Email { get; set; }


        }


        public class Farmer
        {
            public string?FarmerID { get; set; }
            public string? FullName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Password { get; set; }
            public string? FullAddress { get; set; }
            public string? FarmName { get; set; }
            public string? FarmLocation { get; set; }
            public string? FarmingMethod { get; set; }
            public string? Certification { get; set; }
            public string? Email { get; set; }

        }

		public class Product
		{
			public string? ProductID { get; set; }
			public string? ProductName { get; set; }
			public string? CategoryID { get; set; }
			public string? ShortDetails { get; set; }
			public string? Description { get; set; }
			public string? Price { get; set; }
			public string? Discount { get; set; }
			public string? Age { get; set; }
			public string? Breed { get; set; }
			public string? Weight { get; set; }
			public string? Color { get; set; }
			public string? Size { get; set; }
			public string? FeedLotDuration { get; set; }
			public string? Gender { get; set; }
			public string? FeedManagement { get; set; }
			public string? NoOfTeeth { get; set; }
			public string? Height { get; set; }
			public string? FarmerID { get; set; }
			public string? ProductType { get; set; }
			public string? Status { get; set; }
			public string? FeaturedProduct { get; set; } //1
			public string? TopSellingProduct { get; set; } //1
			public string? IsAvailable { get; set; } //1
			public string? Stock { get; set; } //1 
			public string? DiscountProduct { get; set; }// 1
			public string? NewArrival { get; set; } //1

		}

		public class ProductCategory
		{
			public string? CategoryID { get; set; }
			public string? MainCategory { get; set; }
			public string? SubCategory { get; set; }
			public string? Status { get; set; }
		}


		public class Inventory
		{
			public string? ProductID { get; set; }
			public string? ProductName { get; set; }
			public string? CategoryID { get; set; }
			public string? ShortDetails { get; set; }
			public string? Description { get; set; }
			public string? Price { get; set; }
			public string? Discount { get; set; }
			public string? Age { get; set; }
			public string? Breed { get; set; }
			public string? Weight { get; set; }
			public string? Color { get; set; }
			public string? Size { get; set; }
			public string? FeedLotDuration { get; set; }
			public string? Gender { get; set; }
			public string? FeedManagement { get; set; }
			public string? NoOfTeeth { get; set; }
			public string? Height { get; set; }
			public string? ProductType { get; set; }
			public string? Status { get; set; } //0> Requested
			public string? FeaturedProduct { get; set; } //1
			public string? TopSellingProduct { get; set; } //1
			public string? IsAvailable { get; set; } //1
			public string? Stock { get; set; } //1 
			public string? DiscountProduct { get; set; }// 1
			public string? NewArrival { get; set; } //1

			public string? FarmerID { get; set; }
			public string? FullName { get; set; }
			public string? PhoneNumber { get; set; }
			
			public string? FullAddress { get; set; }
			public string? FarmName { get; set; }
			public string? FarmLocation { get; set; }
			public string? FarmingMethod { get; set; }
			public string? Certification { get; set; }
			public string? Email { get; set; }

		}

	}
}
