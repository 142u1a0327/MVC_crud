using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRud.Controllers
{
    public class StuController : Controller
    {
        // GET: Stu
        public ActionResult Index()
        {
            return View();
        }
    }
}