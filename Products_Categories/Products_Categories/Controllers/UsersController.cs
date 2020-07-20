using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products_Categories.Controllers
{
    public class UsersController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegisterUser
        public ActionResult CreateUser()
        {
            return View();
        }
    }
}