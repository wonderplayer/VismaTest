using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using visma_test.Interface;
using visma_test.Models;

namespace visma_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IActionResult Index()
        {
            return View(_serviceProvider.Users);
        }
        [HttpGet]
        [ActionName("UserInfo")]
        public IActionResult UserInfo(int id)
        {
            return View(_serviceProvider.User(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
