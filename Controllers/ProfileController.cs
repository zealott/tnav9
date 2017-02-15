using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ingeniux.Runtime.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/
        public ActionResult Index()
        {
            return View();
        }

		public string LogIn()
		{
			NameValueCollection formCollection = Request.Form; // Grab the form POST content
			string username = Request.Form["username"];
			string password = Request.Form["password"];
			if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
			{
				byte[] data = Encoding.UTF8.GetBytes(password);
				SHA1 algorithm = SHA1.Create();
				byte[] hash = algorithm.ComputeHash(data);
				string base64 = Convert.ToBase64String(hash);
				string ret = "";
				foreach (var item in hash)
				{
					ret += item;
				}
				return ret;
			}
			return ("username: " + username + " | password: " + password);
		}
	}
}