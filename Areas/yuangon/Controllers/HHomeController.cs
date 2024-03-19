using BLL;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System;
using WebApplication1;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Areas.Admin.Filters;

namespace ASP.NET_core_Beauty_system.Areas.yuangon.Controllers
{
    [Area("yuangon"), MyFilter]//设置域的特性属于Admin的
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



        #region 数据添加
        public IActionResult bumen_add() 
        {
            return View();
        }
        public IActionResult bumen_add2(string name)
        {
            ReturnResult result = _userBLL.bumen_add(name);
            if (result.IsSuccess)
            {
                // 操作成功，可以进行进一步处理，比如重新加载页面等
                // 重定向到指定的页面
                return Json(new { isSuccess = true, msg = "添加成功" });
                //
            }
            // 操作失败，可以返回错误信息给前端页面
            return Json(new { isSuccess = false, msg = "添加失败" });

            return View("Error"); // 返回一个名为 Error 的视图用于显示错误信息
        }



        #endregion






        #region 数据添加
        public IActionResult yg_add()
        {

            // 从数据库中获取部门数据
            List<Xueyuan> departments = _userBLL.GetXueyuans(); // 假设该方法可从数据库中获取部门数据

            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            return View();
        }
        public IActionResult yg_add2(string stuid, string  pass, string  sname, string sex, string department)
        {
            ReturnResult result = _userBLL.yg_add(stuid, pass, sname, sex, department);
            if (result.IsSuccess)
            {
                // 操作成功，可以进行进一步处理，比如重新加载页面等
                // 重定向到指定的页面
                return Json(new { isSuccess = true, msg = "添加成功" });
                //
            }
            // 操作失败，可以返回错误信息给前端页面
            return Json(new { isSuccess = false, msg = "添加失败" });
        }



        #endregion





        #region 员工管理
        public IActionResult yggl()
        {





                var Students = _userBLL.GetXStudents();
                return View(Students);
    


        }



        #endregion



        //删除员工操作
        public IActionResult Deleteyg(string id)
        {
            ReturnResult result = _userBLL.deleteyg(id);
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
