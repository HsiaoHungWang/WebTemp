using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace WebTemp.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
         
        }

        public IActionResult SayHi(string name,int age = 20)
        {
            //  return Content("Hello Async Await!!", "text/plain", Encoding.UTF8);
            return Content($"Hello {name}, You are {age} years old!!", "text/plain", Encoding.UTF8);
        }

        
    }
}
