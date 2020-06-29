using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSample.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyTravelDestination(string RecommendTravelDestination)
        {
            List<string> countries = new List<string> {"国内", "海外" };
            if (!countries.Contains(RecommendTravelDestination))
            {
                return Json($"国内か海外を入力してください");
            }

            return Json(true);
        }
    }
}