using PhotoSharing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Test()
        {
            throw new Exception();

            return File(new byte[] { 64, 65, 66, 67, 68, 69 }, "text/plain", "test.txt");

          /*  var photo = new Photo
            {
                PhotoID = 1,
                Title = "Testing",
                Description = "???? bored ???",
                UserName = "Paul",
                CreatedDate = DateTime.Now
            };

            return Json(photo, JsonRequestBehavior.AllowGet);
            */
         //   return Content("<b>Test</b> and <i>more tests</i>");
         //   return RedirectToAction("Index", "Photo");
         //   return Redirect("http://www.google.com");
         //   return HttpNotFound();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
