﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notfound()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        public ActionResult ContentTest()
        {
            return Content("開發實戰", "text/xml", Encoding.GetEncoding("Big5"));
        }

        public ActionResult FileTest()
        {
            var filePath = Server.MapPath("~/Content/PPAP.jpg");

            return File(filePath, "image/jpeg");
        }

        public ActionResult FileTest2()
        {
            var filePath = Server.MapPath("~/Content/PPAP.jpg");

            return File(filePath, "image/jpeg", "PPAP.jpg");
        }
    }
}