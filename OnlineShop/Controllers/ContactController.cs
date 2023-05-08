using Models.DAO;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Models.EF;
using System.IO;

namespace OnlineShop.Controllers
{
    public class ContactController : TwilioController
    {
        // GET: Contact
        public ActionResult Index()
        {        
            return View();
        }

        
        public ActionResult Call()
        {
            return View();
        }

        public ActionResult CallV2()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileData = new byte[file.ContentLength];
                file.InputStream.Read(fileData, 0, file.ContentLength);
                var audioFile = new Audio
                {
                    Name = fileName,
                    Date = fileData
                };

                using(var db  = new OnlineShopDbContext())
                {
                    db.Audios.Add(audioFile); 
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index","Home");
        }
    }
}