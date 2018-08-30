using Login.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                IEnumerable<ApplicationUser> users = db.Users.ToList();
                ViewBag.Users = users;

                return View();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }




        public ActionResult Account()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                IEnumerable<ApplicationUser> users = db.Users.ToList();
                ViewBag.Users = users;
                ViewBag.User = AuthenticationManager.User.Identity.Name.ToString();
                return View();
            }


        }





    }
}