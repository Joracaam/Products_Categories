using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products_Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult AddCategory()
        {
            return View();
        }
    }
}