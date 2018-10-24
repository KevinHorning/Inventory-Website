using System.Web.Mvc;

namespace Atlas2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Inventory() 
        {
            return View();
        }

        public ActionResult Equipment()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }
    }
}