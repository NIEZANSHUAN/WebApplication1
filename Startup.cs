using BLL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            #region 解决.net core运行时，视图被修改，刷新浏览器不更新页面和js的问题
            //第一步先安装nuget包：Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            //第二步：在services.AddControllersWithViews()方法后加.AddRazorRuntimeCompilation()
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #endregion



            #region 配置数据上下文
            services.AddDbContext<CosmetologynzsDBContext>(option => option.UseSqlServer("name=ConnectionStrings:SqlServerStr"));
            #endregion





            #region 启用缓存服务
            //启用缓存服务
            services.AddMemoryCache();
            #endregion
            #region 启用Session服务
            //启用Session服务
            services.AddSession();
            #endregion
            services.AddScoped<UserBLL>();//依赖注入配置

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //启用Session服务↓
            app.UseSession();
            //启用Session服务↑
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Login}/{action=Loginview}/{id?}");
            //});


            app.UseEndpoints(endpoints =>
            {

                //路由

                endpoints.MapAreaControllerRoute(
name: "yuangon",
areaName: "yuangon",
pattern: "{controller=Account}/{action=Loginview}/{id?}");


      //          endpoints.MapAreaControllerRoute(
      // name: "yuangon",
      // areaName: "yuangon",
      //pattern: "{controller=HHome}/{action=index}/{id?}");

                //endpoints.MapAreaControllerRoute(
                // name: "Admin",
                // areaName: "Admin",
                //pattern: "{controller=Account}/{action=Loginview}/{id?}");

















                //endpoints.MapAreaControllerRoute(
                // name: "Admin",
                // areaName: "Admin",
                //pattern: "{controller=Home}/{action=xueyuan}/{id?}");



                //     endpoints.MapAreaControllerRoute(
                // name: "Admin",
                // areaName: "Admin",
                //pattern: "{controller=Home}/{action=index}/{id?}");











                // endpoints.MapAreaControllerRoute(
                //name: "BOSS",
                //areaName: "BOSS",
                //pattern: "BOSS/{controller=Home}/{action=Index}/{id?}");





                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Admin}/{action=Index}/{id?}");





            });

        }

    }
}
