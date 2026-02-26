using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        public IActionResult Index()//右键index添加视图
        {
            return View(ShirtsRepository.GetShirts());
        }
    }
}
