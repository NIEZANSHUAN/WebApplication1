using BLL;
using Common;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Filters;

namespace WebApplication1.Areas.yuangon.Controllers
{
    [Area("yuangon"), MyFilter]//标识域

    public class HomeController : Controller
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

        public IActionResult xueyuan()
        {
            var xueyuans = _userBLL.GetXueyuans();
            return View(xueyuans);
        }

        #endregion



        #region 数据展示2


        public IActionResult daka2()
        {
            var Students = _userBLL.GetXStudents();
            return View(Students);
        }

        #endregion

        #region 




        #endregion


        #region 菜单
        public IActionResult le()
        {
            return View();
        }
        #endregion
        #region 打卡视图+数据展示3考勤数据
        public IActionResult kq()
        {
            var kq = _userBLL.GetXKaoqins();
            return View(kq);

        }
        #endregion

        #region 打卡操作
        public IActionResult daka22(string Stuid, string sex, string sname, string teacher)
        {
            ReturnResult result = _userBLL.Edit(Stuid, sex, sname, teacher);
            if (result.IsSuccess)
            {
                // 操作成功，可以进行进一步处理，比如重新加载页面等
                // 重定向到指定的页面
                return Json(new { isSuccess = true, msg = "修改成功" });
                //
            }
            // 操作失败，可以返回错误信息给前端页面
            return View("Error"); // 返回一个名为 Error 的视图用于显示错误信息
        }

        #endregion



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

        //#region //返回重定向到指定页面
        //public IActionResult RedirectToLoginView()
        //{
        //    return RedirectToAction("Loginview", "Account", new { area = "Admin" });
        //}
        //#endregion

        #region 实现从当前控制器跳转到另一个文件夹下的控制器的主页（index）视图
        public IActionResult vv()
        {
            return RedirectToAction("Loginview", "Account", new { area = "yuangon" });
        }
        #endregion

    }
}
