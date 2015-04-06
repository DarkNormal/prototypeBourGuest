using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testLogin.Models;

namespace testLogin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int statusCode, Exception exception)
        {
            ErrorModel model = new ErrorModel {Exception = exception };
            return View(model);
        }
    }
}