using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication1.Areas.Admin.Filters
{
    public class MyFilterAttribute : Attribute, IActionFilter  //IActionFilter行为筛选器
    {
        //Session:存在服务端，每次关闭链接后会清空。
        //Cookie: 存在客户端浏览器,只有过期或用户主动清除才会消失。






        public void OnActionExecuted(ActionExecutedContext context)//访问后
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)//访问前
        {
            var userIds = context.HttpContext.Session.GetString("UserName");
            var userIdc = context.HttpContext.Request.Cookies["UserName"];
            if (userIdc == null)
            {
                context.Result = new RedirectResult("/Account/Loginview");
            }
        }
    }
}
