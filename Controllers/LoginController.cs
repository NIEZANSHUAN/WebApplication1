using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entity;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Loginview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string userPass, int userType)
        {
            // 在此处编写登录逻辑，比如验证用户名密码等操作
            if (userType == 0)//员工
            {


            }
            else if (userType == 1)//老板
            {

            }
            else if (userType == 2)//管理员
            {
                //admin = db.Admin.FirstOrDefault(a => a.UserName == UserName);
                //if (admin != null)
                //{
                //    if (admin.UserPass == UserPass)
                //    {
                //        return Content("<script>alert('登录成功');location.href='/home/index/'</script>");
                //    }
                //}
            }




            return RedirectToAction("Index");
        }
    }
}
