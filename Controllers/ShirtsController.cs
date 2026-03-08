using Microsoft.AspNetCore.Mvc;
using WebApp.date;
using WebApp.Models;
using WebApp.Models.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {   //通过构造函数注入IWebApiExecuter接口的实例，
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
            return  View(await webApiExecuter.InvokeGet<List<Shirt>>("shirts"));
        }
      /*  public IActionResult Index()
        {
            return View(ShirtsRepository.GetShirts());
        }*/
    }
}
