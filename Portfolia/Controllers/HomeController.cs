using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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

        public async Task<PartialViewResult> DownloadList(string password)
        {
            var db = new DataBase();

            var downloadObj = await db.LegitimationList.FirstOrDefaultAsync
                (d => d.Password == password && !d.Used &&
                      d.RegisterDate >= DateTime.Now.AddDays(-14) );
            var oldDwn = downloadObj;

            if (downloadObj != null)
            {
                var fileList = await db.Files.Select(d => d).ToListAsync();

                downloadObj.Used = true;
                downloadObj.UsedDate = DateTime.Now;
                db.Entry(oldDwn).CurrentValues.SetValues(downloadObj);
                await db.SaveChangesAsync();

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
    }
}