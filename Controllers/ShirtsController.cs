using Microsoft.AspNetCore.Mvc;
using WebApp.date;
using WebApp.Models;
using WebApp.Models.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        //使得ShirtsController能够使用webApiExecuter来调用Web API获取数据。
        private readonly IWebApiExecuter webApiExecuter;


        public ShirtsController(IWebApiExecuter webApiExecuter)
        {
            this.webApiExecuter = webApiExecuter;
        }
        //使用async和await关键字来异步调用webApiExecuter的InvokeGet方法
        //获取Tshirt类型的列表数据，并将其传递给视图进行显示。
        public async Task<IActionResult> Index()
        {
            var shirts = await webApiExecuter.InvokeGet<List<Shirt>>("shirts");
            return View(shirts);

        }
        public IActionResult CreateShirt()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateShirt(Shirt shirt)
        {

            return View(shirt);

        }
    }
}
