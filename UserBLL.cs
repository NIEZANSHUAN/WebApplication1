using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserBLL
    {
        UserDAL userDAL=new UserDAL();//实例化用户表的数据访问层

        public ReturnResult Login(string UserName, string PassWord)
        {
            if(string.IsNullOrWhiteSpace(UserName)|| string.IsNullOrWhiteSpace(PassWord))
            {
                return new ReturnResult("账号或密码不能为空");
            }
            //加密密码
            PassWord = MD5passwd.GenerateMD5(PassWord);//
                tb_User lologinUser=userDAL.Login(UserName, PassWord);
                if(lologinUser != null)
                {
                    return new ReturnResult("账号或密码错误");
                }
                return new ReturnResult(200, "登录成功", true, lologinUser, 0);//成功的回调  200是成功的意思
            
        }

    }
}
