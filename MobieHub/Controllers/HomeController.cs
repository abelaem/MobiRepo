using Domain.Entities;
using Services;
using System.Web.Mvc;

namespace MovieHub.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MobiService<Product> _mobiService;


        public HomeController()
        {
            _mobiService = new MobiService<Product>();
        }

        public ActionResult Index()
        {
            var movie = _mobiService.GetAll();

            return View(movie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}