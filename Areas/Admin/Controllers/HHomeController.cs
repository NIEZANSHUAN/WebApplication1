using BLL;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace ASP.NET_core_Beauty_system.Areas.Admin.Controllers
{
    [Area("Admin")]//设置域的特性属于Admin的
    public class HHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        #region 数据展示
        UserBLL _userBLL = new UserBLL(new CosmetologynzsDBContext());//实例化用户表的数据访问层

        //public HomeController(CosmetologynzsDBContext context)
        //{
        //    _userBLL = new UserBLL(context);
        //}

        public IActionResult Xueyuan()
        {
           var xueyuans = _userBLL.GetXueyuans();
            return View(xueyuans);
        }

        #endregion

        public IActionResult left()
        {
            return View();
        }

        //删除操作
        public IActionResult Delete(int id)
        {
            ReturnResult result = _userBLL.Delete(id);
            if (result.IsSuccess)
            {
                // 操作成功，可以进行进一步处理，比如重新加载页面等
                // 重定向到指定的页面
                return Json(new { isSuccess = true, msg = "删除成功" });
                //
            }
            // 操作失败，可以返回错误信息给前端页面
            return View("Error"); // 返回一个名为 Error 的视图用于显示错误信息
        }
        
    }
}
