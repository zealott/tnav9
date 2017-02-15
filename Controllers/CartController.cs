using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ingeniux.Runtime.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            return View();
        }


		public bool AddItemToCart()
		{
			string productID = Request.QueryString["productId"] ?? "";
			if (!string.IsNullOrWhiteSpace(productID))
			{
				List<String> productList = Session["productList"] as List<String> ?? new List<String>();
				if(!productList.Contains(productID))
				{
					productList.Add(productID);
					Session.Add("productList", productList);
					Session.Add("productCount", productList.Count);
					return true;
				}
				return false;
			}
			return false; 
		}
	}
}