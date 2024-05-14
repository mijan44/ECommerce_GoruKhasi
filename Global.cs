using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using static Ecom_GoruKhasi.Globals;

namespace Ecom_GoruKhasi
{
	public class Globals
	{
		//HASH Generator
		public class Authenticator
		{
			public static string GenarateHash(int length = 20)
			{
				const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
				StringBuilder res = new StringBuilder();
				using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
				{
					byte[] uintBuffer = new byte[sizeof(uint)];

					while (length-- > 0)
					{
						rng.GetBytes(uintBuffer);
						uint num = BitConverter.ToUInt32(uintBuffer, 0);
						res.Append(valid[(int)(num % (uint)valid.Length)]);
					}
				}

				return res.ToString();
			}
		}
		// END

		public class db
		{
			public static string ConnectionString()
			{

				return "Data Source=neurochip.cpxfsvojtlbk.ap-southeast-1.rds.amazonaws.com;Initial Catalog=GoruKhasi;User Id=NeurochipAdmin;password=19815192";
			}
		}



		public class getDbData
		{
			//Function start
			public static List<Model.User> LoginAuth(string phone, string password)
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[UserDetails] where [PhoneNumber]='" + phone + "' and [Password]='" + password + "'", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.User> user = new List<Model.User>();

							return user = (from DataRow dr in dt.Rows
										   select new Model.User()
										   {
											   UserID = dr["ID"].ToString(),
											   FullName = dr["FullName"].ToString(),
											   Email = dr["Email"].ToString(),
											   PhoneNumber = dr["PhoneNumber"].ToString(),
											   Password = dr["Password"].ToString(),



										   }).ToList();
						}
						else
						{
							return new List<Model.User>();
						}

					}
				}

			}
			//Function END


			//Function start
			public static List<Model.Admin> AdminLoginAuth(string phone, string password)
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[AdminDetails] where [PhoneNumber]='" + phone + "' and [Password]='" + password + "'", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.Admin> user = new List<Model.Admin>();

							return user = (from DataRow dr in dt.Rows
										   select new Model.Admin()
										   {
											   AdminID = dr["AdminID"].ToString(),
											   FullName = dr["FullName"].ToString(),
											   Email = dr["Email"].ToString(),
											   PhoneNumber = dr["PhoneNumber"].ToString(),
											   Password = dr["Password"].ToString(),



										   }).ToList();
						}
						else
						{
							return new List<Model.Admin>();
						}

					}
				}

			}
			//Function END


			//Function start
			public static List<Model.Farmer> FarmerLoginAuth(string phone, string password)
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[FarmerDetails] where [PhoneNumber]='" + phone + "' and [Password]='" + password + "'", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.Farmer> farmer = new List<Model.Farmer>();

							return farmer = (from DataRow dr in dt.Rows
											 select new Model.Farmer()
											 {
												 FarmerID = dr["FarmerID"].ToString(),
												 FullName = dr["FullName"].ToString(),
												 Email = dr["Email"].ToString(),
												 PhoneNumber = dr["PhoneNumber"].ToString(),
												 Password = dr["Password"].ToString(),



											 }).ToList();
						}
						else
						{
							return new List<Model.Farmer>();
						}

					}
				}

			}
			//Function END

			public static List<Model.ProductCategory> AllCategories()
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[ProductCategory]", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.ProductCategory> course = new List<Model.ProductCategory>();

							return course = (from DataRow dr in dt.Rows
											 select new Model.ProductCategory()
											 {

												 CategoryID = dr["CategoryID"]?.ToString(),
												 MainCategory = dr["MainCategory"]?.ToString(),
												 SubCategory = dr["SubCategory"]?.ToString(),
												 Status = dr["Status"]?.ToString()
												 


											 }).ToList();
						}
						else
						{
							return new List<Model.ProductCategory>();
						}

					}
				}
			}
			// Function END




			public static List<Model.Inventory> Inventories()
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[ProductFarmerView]", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.Inventory> course = new List<Model.Inventory>();

							return course = (from DataRow dr in dt.Rows
											 select new Model.Inventory()
											 {

												 ProductID = dr["ProductID"]?.ToString(),
												 ProductName = dr["ProductName"]?.ToString(),
												 CategoryID = dr["CategoryID"]?.ToString(),
												 ShortDetails = dr["ShortDetails"]?.ToString(),
												 Description = dr["Description"]?.ToString(),
												 Price = dr["Price"]?.ToString(),
												 Discount = dr["Discount"]?.ToString(),
												 Age = dr["Age"]?.ToString(),
												 Breed = dr["Breed"]?.ToString(),
												 Weight = dr["Weight"]?.ToString(),
												 Color = dr["Color"]?.ToString(),
												 Size = dr["Size"]?.ToString(),
												 FeedLotDuration = dr["FeedLotDuration"]?.ToString(),
												 Gender = dr["Gender"]?.ToString(),
												 FeedManagement = dr["FeedManagement"]?.ToString(),
												 NoOfTeeth = dr["NoOfTeeth"]?.ToString(),
												 Height = dr["Height"]?.ToString(),
												 ProductType = dr["ProductType"]?.ToString(),
												 Status = dr["Status"]?.ToString(),
												 FeaturedProduct = dr["FeaturedProduct"]?.ToString(),
												 TopSellingProduct = dr["TopSellingProduct"]?.ToString(),
												 IsAvailable = dr["IsAvailable"]?.ToString(),

												 Stock = dr["Stock"]?.ToString(),
												 DiscountProduct = dr["DiscountProduct"]?.ToString(),
												 NewArrival = dr["NewArrival"]?.ToString(),
												 FarmerID = dr["FarmerID"]?.ToString(),
												 FullName = dr["FullName"]?.ToString(),
												 PhoneNumber = dr["PhoneNumber"]?.ToString(),
												 FullAddress = dr["FullAddress"]?.ToString(),
												 FarmName = dr["FarmName"]?.ToString(),
												 FarmLocation = dr["FarmLocation"]?.ToString(),
												 FarmingMethod = dr["FarmingMethod"]?.ToString(),
												 Certification = dr["Certification"]?.ToString(),
												 Email = dr["Email"]?.ToString()



											 }).ToList();
						}
						else
						{
							return new List<Model.Inventory>();
						}

					}
				}
			}
			// Function END


			public static List<Model.Product> ProductDetails(string ID)
			{
				using (SqlConnection con = new SqlConnection(db.ConnectionString()))
				{
					// MessageBox.Show("SELECT ProductName FROM Products WHERE ProductName like  '" + SearchString + "'");
					using (SqlCommand cmd = new SqlCommand("SELECT * FROM [GoruKhasi].[dbo].[ProductDetails] Where [ProductID]='" + ID + "'", con))
					{
						con.Open();

						SqlDataReader sdr = cmd.ExecuteReader();

						if (sdr.Read())
						{
							con.Close();
							con.Open();

							SqlDataAdapter da = new SqlDataAdapter(cmd);
							DataSet ds = new DataSet();
							da.Fill(ds, "DataTable1");
							con.Close();

							DataTable dt = ds.Tables["DataTable1"];


							List<Model.Product> Product = new List<Model.Product>();

							return Product = (from DataRow dr in dt.Rows
											 select new Model.Product()
											 {

												 ProductID = dr["ProductID"]?.ToString(),
												 ProductName = dr["ProductName"]?.ToString(),
												 CategoryID = dr["CategoryID"]?.ToString(),
												 ShortDetails = dr["ShortDetails"]?.ToString(),
												 Description = dr["Description"]?.ToString(),
												 Price = dr["Price"]?.ToString(),
												 Discount = dr["Discount"]?.ToString(),
												 Age = dr["Age"]?.ToString(),
												 Breed = dr["Breed"]?.ToString(),
												 Weight = dr["Weight"]?.ToString(),
												 Color = dr["Color"]?.ToString(),
												 Size = dr["Size"]?.ToString(),
												 FeedLotDuration = dr["FeedLotDuration"]?.ToString(),
												 Gender = dr["Gender"]?.ToString(),
												 FeedManagement = dr["FeedManagement"]?.ToString(),
												 NoOfTeeth = dr["NoOfTeeth"]?.ToString(),
												 Height = dr["Height"]?.ToString(),
												 ProductType = dr["ProductType"]?.ToString(),
												 Status = dr["Status"]?.ToString(),
												 FeaturedProduct = dr["FeaturedProduct"]?.ToString(),
												 TopSellingProduct = dr["TopSellingProduct"]?.ToString(),
												 IsAvailable = dr["IsAvailable"]?.ToString(),

												 Stock = dr["Stock"]?.ToString(),
												 DiscountProduct = dr["DiscountProduct"]?.ToString(),
												 NewArrival = dr["NewArrival"]?.ToString(),
												 FarmerID = dr["FarmerID"]?.ToString()
												 



											 }).ToList();
						}
						else
						{
							return new List<Model.Product>();
						}

					}
				}
			}
			// Function END




		}
		public class Create
		{
			//Function START
			public static void AddProduct(
				string ProductName,

				string ShortDetails,
				string Description,
				string Price,
				string Discount,
				string Age,
				string Breed,
				string Weight,
				string Color,
				string Size,
				string FeedLotDuration,
				string Gender,
				string FeedManagement,
				string NoOfTeeth,
				string Height,
				string FarmerID,
				string ProductType
				//string FeaturedProduct ,
				//string TopSellingProduct ,
				//string IsAvailable ,
				//string Stock ,
				//string DiscountProduct ,
				//string NewArrival



				)

			{
				string ProductID = ProductName + "_" + Authenticator.GenarateHash();

				using (SqlConnection connec = new SqlConnection(db.ConnectionString()))
				{
					using (SqlCommand cmd = new SqlCommand("InsertNewProductDetails", connec))
					{

						connec.Open();

						cmd.CommandType = CommandType.StoredProcedure;




						cmd.Parameters.AddWithValue("@ProductID", ProductID);
						cmd.Parameters.AddWithValue("@ProductName", ProductName);
						cmd.Parameters.AddWithValue("@CategoryID", "NULL");
						cmd.Parameters.AddWithValue("@ShortDetails", ShortDetails);
						cmd.Parameters.AddWithValue("@Rating", "5.0");
						cmd.Parameters.AddWithValue("@Description", Description);
						cmd.Parameters.AddWithValue("@Price", Price);
						cmd.Parameters.AddWithValue("@Discount", Discount);
						cmd.Parameters.AddWithValue("@Age", Age);

						cmd.Parameters.AddWithValue("@Breed", Breed);
						cmd.Parameters.AddWithValue("@Weight", Weight);
						cmd.Parameters.AddWithValue("@Color", Color);
						cmd.Parameters.AddWithValue("@Size", Size);

						cmd.Parameters.AddWithValue("@FeedLotDuration", FeedLotDuration);
						cmd.Parameters.AddWithValue("@Gender", Gender);
						cmd.Parameters.AddWithValue("@FeedManagement", FeedManagement);
						cmd.Parameters.AddWithValue("@NoOfTeeth", NoOfTeeth);

<<<<<<< HEAD










        }
=======
						cmd.Parameters.AddWithValue("@Height", Height);
						cmd.Parameters.AddWithValue("@FarmerID", FarmerID);
						cmd.Parameters.AddWithValue("@ProductType", ProductType);
						cmd.Parameters.AddWithValue("@Status", "0");
						cmd.Parameters.AddWithValue("@FeaturedProduct", "1");
						cmd.Parameters.AddWithValue("@TopSellingProduct", "1");
>>>>>>> 2841e223d18c51db6793458b2fb12c28688c164d

						cmd.Parameters.AddWithValue("@IsAvailable", "1");
						cmd.Parameters.AddWithValue("@Stock", "1");
						cmd.Parameters.AddWithValue("@DiscountProduct", "1");
						cmd.Parameters.AddWithValue("@NewArrival", "1");








						cmd.ExecuteNonQuery();
						connec.Close();


<<<<<<< HEAD
    }
=======
					}




				}
			}
			//Function END

			public static void AddCategory(
				string MainCategory, string SubCategory



			)

			{
				string CategoryID = SubCategory + Authenticator.GenarateHash();

				using (SqlConnection connec = new SqlConnection(db.ConnectionString()))
				{
					using (SqlCommand cmd = new SqlCommand("InsertNewProductCategory", connec))
					{

						connec.Open();

						cmd.CommandType = CommandType.StoredProcedure;




						cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
						cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
						cmd.Parameters.AddWithValue("@SubCategory", SubCategory);
						cmd.Parameters.AddWithValue("@Status", "1");








						cmd.ExecuteNonQuery();
						connec.Close();


					}




				}
			}
			//Function END

			public static void Register(

	 string FullName,
	 string Email,
	 string PhoneNumber,
	 string Password,
	 string District,
	 string Area


)

			{
				string ID;
				ID = "GKH_" + Authenticator.GenarateHash();


				using (SqlConnection connec = new SqlConnection(db.ConnectionString()))
				{
					using (SqlCommand cmd = new SqlCommand("InsertNewUserDetails", connec))
					{

						connec.Open();

						cmd.CommandType = CommandType.StoredProcedure;



						cmd.Parameters.AddWithValue("@ID", ID);
						cmd.Parameters.AddWithValue("@FullName", string.IsNullOrEmpty(FullName) ? DBNull.Value : (object)FullName);
						cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
						cmd.Parameters.AddWithValue("@PhoneNumber", string.IsNullOrEmpty(PhoneNumber) ? DBNull.Value : (object)PhoneNumber);
						cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(Password) ? DBNull.Value : (object)Password);
						cmd.Parameters.AddWithValue("@District", string.IsNullOrEmpty(District) ? DBNull.Value : (object)District);
						cmd.Parameters.AddWithValue("@Area", string.IsNullOrEmpty(Area) ? DBNull.Value : (object)Area);

						//cmd.Parameters.AddWithValue("@Role", "user");




						cmd.ExecuteNonQuery();
						connec.Close();


					}




				}
			}
			//Function END


		}







	}

	public class Update
	{
		public static void UpdateRequestProduct(string ProductID,
									string ProductName,
									string ShortDetails,
									string Description,
									string Price,
									string Discount,
									string Age,
									string Breed,
									string Weight,
									string Color,
									string Size,
									string FeedLotDuration,
									string Gender,
									string FeedManagement,
									string NoOfTeeth,
									string Height,
									string FarmerID,
									string ProductType)
		{
			using (SqlConnection connec = new SqlConnection(db.ConnectionString()))
			{
				using (SqlCommand cmd = new SqlCommand("UPDATE [GoruKhasi].[dbo].[ProductDetails] SET ProductName = @ProductName, ShortDetails = @ShortDetails, Description = @Description, Price = @Price, Discount = @Discount, Age = @Age, Breed = @Breed, Weight = @Weight, Color = @Color, Size = @Size, FeedLotDuration = @FeedLotDuration, Gender = @Gender, FeedManagement = @FeedManagement, NoOfTeeth = @NoOfTeeth, Height = @Height,  ProductType = @ProductType WHERE ProductID = @ProductID", connec))
				{
					connec.Open();

					cmd.Parameters.AddWithValue("@ProductID", ProductID);
					cmd.Parameters.AddWithValue("@ProductName", ProductName);
					cmd.Parameters.AddWithValue("@ShortDetails", ShortDetails);
					cmd.Parameters.AddWithValue("@Description", Description);
					cmd.Parameters.AddWithValue("@Price", Price);
					cmd.Parameters.AddWithValue("@Discount", Discount);
					cmd.Parameters.AddWithValue("@Age", Age);
					cmd.Parameters.AddWithValue("@Breed", Breed);
					cmd.Parameters.AddWithValue("@Weight", Weight);
					cmd.Parameters.AddWithValue("@Color", Color);
					cmd.Parameters.AddWithValue("@Size", Size);
					cmd.Parameters.AddWithValue("@FeedLotDuration", FeedLotDuration);
					cmd.Parameters.AddWithValue("@Gender", Gender);
					cmd.Parameters.AddWithValue("@FeedManagement", FeedManagement);
					cmd.Parameters.AddWithValue("@NoOfTeeth", NoOfTeeth);
					cmd.Parameters.AddWithValue("@Height", Height);
					//cmd.Parameters.AddWithValue("@FarmerID", FarmerID);
					cmd.Parameters.AddWithValue("@ProductType", ProductType);

					cmd.ExecuteNonQuery();
					connec.Close();
				}
			}
		}


		public static void ConfirmProduct(string ID)
		{
			using (SqlConnection connec = new SqlConnection(db.ConnectionString()))
			{
				using (SqlCommand cmd = new SqlCommand("UPDATE [GoruKhasi].[dbo].[ProductDetails] SET [Status] ='1' where [ProductID]='" + ID + "' ", connec))
				{
					connec.Open();

					cmd.Parameters.AddWithValue("@ProductID", ID);
					cmd.Parameters.AddWithValue("@Status","1" );
					

					cmd.ExecuteNonQuery();
					connec.Close();
				}
			}
		}







	}
>>>>>>> 2841e223d18c51db6793458b2fb12c28688c164d
}





















