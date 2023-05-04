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

        public IActionResult SayHi()
        {
            return Content("Hello Ajax!!", "text/plain", Encoding.UTF8);
        }

        
    }
}
