using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();
        //可用於找不到Controller的Action的時機
        protected override void HandleUnknownAction(string actionName)
        {
            //base.HandleUnknownAction(actionName);
            this.RedirectToAction("Index").ExecuteResult(this.ControllerContext);
        }
    }
}