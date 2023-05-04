using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebTemp.Models;

namespace WebTemp.Controllers
{
    public class MemberController : Controller
    {
        private readonly NorthwindContext _context;

        public MemberController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
         
        }

        public IActionResult SayHi(string name,int age = 20)
        {
            //  return Content("Hello Async Await!!", "text/plain", Encoding.UTF8);
            return Content($"Hello {name}, You are {age} years old!!", "text/plain", Encoding.UTF8);
        }

        public IActionResult Register() {
            return View();   
          }

        public IActionResult CheckName(string name)
        {
            var exists = _context.Employees.Any(e => e.FirstName == name);
            return Content(exists.ToString());
        }

        
    }
}
