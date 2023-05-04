using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTemp.Models;

namespace WebTemp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;
        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AutoComplete()
        {
            return View();
        }

        public IActionResult GetProducts(string keyword)
        {
          var products =  _context.Products.Where(p => p.ProductName.Contains(keyword)).Select(p => p.ProductName);
            return Json(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}