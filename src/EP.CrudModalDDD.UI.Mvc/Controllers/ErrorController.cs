using System.Web.Mvc;

namespace EP.CrudModalDDD.UI.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("403");
        }

        public ActionResult InternalServerError()
        {
            return View("Error");
        }
    }
}