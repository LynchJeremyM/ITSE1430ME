/* Jeremy Lynch
 * ITSE 1430
 * 12/9/2018
 */
using System.Web.Mvc;

namespace EventPlanner.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}