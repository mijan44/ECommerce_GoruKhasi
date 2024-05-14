using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using static Ecom_GoruKhasi.Globals;

namespace Ecom_GoruKhasi.Controllers
{
    public class Account : Controller
    {

        private void UpdateLayout()
        {
			//Get All Product Category
			
			var Categories = getDbData.AllCategories();

			if (Categories != null)
			{
				ViewBag.Categories = Categories;
			}
			else
			{
				throw new Exception("No Categories Available");
			}

			//Get All Product Request

			var Inventories = getDbData.Inventories();

			if (Inventories != null)
			{
				ViewBag.Inventories = Inventories;
			}
			else
			{
				throw new Exception("No Reqest Available");
			}




		}









        //Farmer Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }

        //Admin Dashboard
		public IActionResult AdminDashboard()
		{
			return View();
		}


		//Login validation

		[HttpPost]
        public IActionResult LoginValidate(string phone, string password, string IsRememberME)
        {


            List<Model.User> User = getDbData.LoginAuth(phone, password);
            List<Model.Admin> Admin = getDbData.AdminLoginAuth(phone, password);
            List<Model.Farmer> Farmer = getDbData.FarmerLoginAuth(phone, password);







            if (User.Count == 1)
            {

                TempData["Success"] = "Login Successful";
                TempData["Header"] = "Welcome to Dashboard";

                CookieOptions options = new CookieOptions();

                if (IsRememberME == "on")
                {
                    options.Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    options.Expires = DateTime.Now.AddDays(7);
                }



                Response.Cookies.Append("UserID", User.FirstOrDefault().UserID, options);
                Response.Cookies.Append("Name", User.FirstOrDefault().FullName, options);
                Response.Cookies.Append("Email", User.FirstOrDefault().Email, options);
                Response.Cookies.Append("PhoneNumber", User.FirstOrDefault().PhoneNumber, options);
               

                return RedirectToAction("UserProfile","Home");
            }

            else if (Admin.Count == 1)
            {

                TempData["Success"] = "Login Successful";
                TempData["Header"] = "Welcome to Dashboard";

                CookieOptions options = new CookieOptions();

                if (IsRememberME == "on")
                {
                    options.Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    options.Expires = DateTime.Now.AddDays(7);
                }



                Response.Cookies.Append("AdminID", Admin.FirstOrDefault().AdminID, options);
                Response.Cookies.Append("Name", Admin.FirstOrDefault().FullName, options);
                Response.Cookies.Append("Email", Admin.FirstOrDefault().Email, options);
                Response.Cookies.Append("PhoneNumber", Admin.FirstOrDefault().PhoneNumber, options);


                return RedirectToAction("Dashboard");
            }

            else if (Farmer.Count == 1)
            {

                TempData["Success"] = "Login Successful";
                TempData["Header"] = "Welcome to Dashboard";

                CookieOptions options = new CookieOptions();

                if (IsRememberME == "on")
                {
                    options.Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    options.Expires = DateTime.Now.AddDays(7);
                }



                Response.Cookies.Append("FarmerID", Farmer.FirstOrDefault().FarmerID, options);
                Response.Cookies.Append("Name", Farmer.FirstOrDefault().FullName, options);
                Response.Cookies.Append("Email", Farmer.FirstOrDefault().Email, options);
                Response.Cookies.Append("PhoneNumber", Farmer.FirstOrDefault().PhoneNumber, options);


                return RedirectToAction("Dashboard");
            }

            else
            {

                TempData["Warning"] = "Incorrect Credentials";
                TempData["Header"] = "Please Try Again";
                return RedirectToAction("Login");
            }



        }

		//Logout

		public IActionResult Logout()
		{
			Response.Cookies.Delete("UserID");
			Response.Cookies.Delete("AdminID");
			Response.Cookies.Delete("FarmerID");
			Response.Cookies.Delete("Name");
			Response.Cookies.Delete("Email");
			Response.Cookies.Delete("PhoneNumber");

			return RedirectToAction("Index","Home");
		}

		//Category

		public IActionResult Category()
		{
            UpdateLayout();
			return View();
		}

        //Add new Category

        [HttpPost]
		public IActionResult AddCategory(string MainCategory, string SubCategory)
		{
            Create.AddCategory(MainCategory, SubCategory);
			return RedirectToAction("Category");
		}

		// Add product
		public IActionResult AddProduct()
		{
			UpdateLayout();

			return View();
		}

		// Update product
		public IActionResult UpdateProduct(string ID)
		{
			UpdateLayout();
			dynamic LandingData = new ExpandoObject();

			List<Model.Product> Product = getDbData.ProductDetails(ID);



			LandingData.Product = Product;


			return View(LandingData);

		}

		public IActionResult AddNewProduct(string ProductName,
			
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
			Create.AddProduct(ProductName,
			 
			 ShortDetails,
			 Description,
			 Price,
			 Discount,
			 Age,
			 Breed,
			 Weight,
			 Color,
			 Size,
			 FeedLotDuration,
			 Gender,
			 FeedManagement,
			 NoOfTeeth,
			 Height,
			 FarmerID,
			 ProductType);

            return RedirectToAction("Inventory");
		}

		//Update Request Product

		[HttpPost]
		public IActionResult UpdateRequestProduct(string ProductID,
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
			Update.UpdateRequestProduct(ProductID,
				ProductName,

			 ShortDetails,
			 Description,
			 Price,
			 Discount,
			 Age,
			 Breed,
			 Weight,
			 Color,
			 Size,
			 FeedLotDuration,
			 Gender,
			 FeedManagement,
			 NoOfTeeth,
			 Height,
			 FarmerID,
			 ProductType);

			return RedirectToAction("Inventory");
		}



		public IActionResult ConfirmProduct(string ID)
		{
			Update.ConfirmProduct(ID);

			return RedirectToAction("Inventory");
		}





		public IActionResult Review()
        {
            return View();
        }


        public IActionResult UserProfile()
        {
            return View();
        }

		public IActionResult FarmerProfile()
		{
			return View();
		}

		//Subcribers

		public IActionResult Subscribers()
		{
			return View();
		}


		//Manage Order

		public IActionResult Orders()
		{
			return View();
		}

		//View order history (Customer)

		public IActionResult ViewOrder()
		{
			return View();
		}


		//Manage Inventory

		public IActionResult Inventory()
		{
			UpdateLayout();

			return View();
		}

		

		

		// Admin

		

		public IActionResult UserAccounts()
		{
			return View();
		}

		public IActionResult FarmerAccounts()
		{
			return View();
		}

		// UI problem
		public IActionResult QuestionsAndAnswers()
		{
			return View();
		}

        // Add Marketing Campaign

        public IActionResult AddMarketingCampaign()
        {
            return View();
        }
		public IActionResult ViewMarketingCampaign()
        {
            return View();
        }
		public IActionResult NegotiatePrice()
        {
            return View();
        }

        //Home page slider control from Admin

        public IActionResult AddSlider()
        {
            return View();
        }
    }
}
