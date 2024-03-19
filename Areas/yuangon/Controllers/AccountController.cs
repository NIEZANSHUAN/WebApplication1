using BLL;
using Common;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WebApplication1.daka.Admin.Controllers
{
    [Area("yuangon")]//标识域
    //"[Area("Admin")]"代表的意思是在C#中用于定义属性的一种方式，通常用于控制访问权限。在这个例子中，“Admin”可能代表了一个特定的权限级别或者用户角色，
    //    在代码中可以根据这个属性来限制特定操作或功能只对具有该权限的用户开放。
    public class AccountController : Controller
    {

        //验证码之类的 缓存
        private readonly IMemoryCache _memoryCache;// 声明接口类型             接口也可以实例化
        public AccountController(IMemoryCache memoryCache) //构造
        {

            _memoryCache = memoryCache;
        }




        /// <summary>
        /// 实例化业务逻辑层
        /// </summary>
          UserBLL _userBLL = new UserBLL();

        public IActionResult Loginview()
        {


            //添加不允许后退操作
            var useidSession = HttpContext.Session.GetString("UserId");

            var useidcookie = HttpContext.Request.Cookies["UserId"];
            if (useidcookie != null)
            {
                return RedirectToAction("index,home");  //回到首页
            }
            return View();
        }

        #region 实现从当前控制器跳转到另一个文件夹下的控制器的主页（index）视图
        public IActionResult YourActionName()
            {
            return RedirectToAction("Index", "Home", new { area = "yuangon" });
        }
        #endregion

        [HttpPost]//加的特性
        //UI 层（Controller）---
        public IActionResult Login(string UserName, string PassWord, string captcha, string appid,int dropdown)  //ul层只负责传数据  给BLL进行判断
        {

         


           

            

            //用户ID数据库的
            int userId = 0;
            //判断验证码是否一样
            //1先把验证码转成小写
            captcha = captcha.ToLowerInvariant();
            //2取出缓存中的验证码
            string code = _memoryCache.Get(appid).ToString();  //调用 _memoryCache.Get(appid) 方法从内存缓存中检索与给定 appid 关联的对象
            if (string.IsNullOrWhiteSpace(code))
            {
                return Json(new ReturnResult("验证码过期，重新获取"));
            }
            if (captcha != code)
            {
                return Json(new ReturnResult("验证码错误"));

            }


            ReturnResult _result = _userBLL.Login(UserName, PassWord, out userId);//调用业务逻辑层登录方法   out关键字可以把数据带出来
            if (_result.Code == 200)
            {
                 

                    //Session代表一个会话有一个ID 用其他浏览器又是另一个ID 一旦关闭就清除
                    HttpContext.Session.SetString("UserName", userId.ToString());//存入Session


                Response.Cookies.Append("UserName", UserName.ToString(), new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(1),
                });

                if (dropdown == 100)
                {
                  

                   
                    return Json(new { code = 200, msg = "员工页面", redirectUrl = Url.Action("index", "Home", new { area = "yuangon" }) });
                }
                else if (dropdown == 102)
                {
                    return Json(new { code = 200, msg = "管理员页面", redirectUrl = Url.Action("index", "HHome", new { area = "yuangon" }) });
                }



                // return Json(_result);

            }

            return Json(new ReturnResult("错误"));

        }

        [HttpGet]
        public IActionResult VerifyCode(string appid)  //返回类型用IActionResult      这个方法用于把验证码变成图片
        {
            string code = "";//用于记录验证码
            //生成验证码
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            //把验证码转成小写
            code = code.ToLowerInvariant();
            //存入缓存
            _memoryCache.Set(appid, code, System.DateTime.Now.AddMinutes(1));//appid代表打开的窗口 ， code验证码和过期时间
            //把Bitmap转成图片
            using (MemoryStream ms = new MemoryStream())  //引用内置的一个转成图片的 System.IO;
            {
                bitmap.Save(ms, ImageFormat.Gif);
                return File(ms.ToArray(), "imags/gif");
            }
        }


    }
}
