using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace WebTemp.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            //html => 顯示 + 資料
            return Content("會員首頁", "text/plain", Encoding.UTF8);
        }

        
    }
}
