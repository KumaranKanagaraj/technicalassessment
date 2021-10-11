using System;
using System.Web.Mvc;

namespace WebExperience.Test.Controllers
{
	public class AssetViewController : Controller
    {
        // GET: AssetView
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("asset/{id}")]
        public ActionResult Asset(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}