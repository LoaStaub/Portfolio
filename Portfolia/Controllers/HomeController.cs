using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Portfolia.Models;
using Portfolia.Models.DbModels;

namespace Portfolia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Skills()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public PartialViewResult DownloadList(string password)
        {
            var db = new DataBase();
            var dateTime = DateTime.Now.AddDays(-14);
            var downloadObj = db.LegitimationList.FirstOrDefault
                (d => d.Password == password && !d.Used &&
                      d.RegisterDate >=  dateTime);
            var oldDwn = downloadObj;

            if (downloadObj != null)
            {
                var fileList = db.Files.Select(d => d).ToList();

                downloadObj.Used = true;
                downloadObj.UsedDate = DateTime.Now;
                db.Entry(oldDwn).CurrentValues.SetValues(downloadObj);
                db.SaveChanges();

                return PartialView("_DownloadList", fileList);
            }

            return null;
        }

        public FileResult DownloadFile(string id)
        {
            var db = new DataBase();
            var idInt = Convert.ToInt32(id);
            var file = db.Files.FirstOrDefault(d => d.Id == idInt);

            if (file != null)
            {
                return File(file.File, file.ContentType, file.FileName);
            }

            return null;
        }

        //public ContentResult SaveFileToDataBase()
        //{
        //    var path = @"C:\lebenslauf.pdf";
        //    var bytes = System.IO.File.ReadAllBytes(path);
        //    var newFile = new Files
        //    {
        //        TimeStamp = DateTime.Now,
        //        ContentType = "Application/pdf",
        //        File = bytes,
        //        FileName = "Lebenslauf.pdf"
        //    };
        //    var db = new DataBase();
        //    db.Files.Add(newFile);
        //    db.SaveChanges();
        //    return Content("HI");
        //}
    }
}