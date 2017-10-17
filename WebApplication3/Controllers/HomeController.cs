using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<Image> model;
            using (Db db = new Db())
            {
                model = db.Images.ToArray().OrderBy(x => x.Sorting).ToList();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file,Image img)
        {
            byte[] array = null;
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
            }
            using (Db db = new Db())
            {
                var image = new Image()
                {
                    Content = array,
                    Description = img.Description,
                    Sorting = 100
                };
                db.Images.Add(image);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void DeleteImage(int id)
        {
            using (Db db = new Db())
            {
                var img = db.Images.Find(id);
                if (img != null)
                {
                    db.Images.Remove(img);
                    db.SaveChanges();
                }
            }
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
