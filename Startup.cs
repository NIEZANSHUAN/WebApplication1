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
            #region ���.net core����ʱ����ͼ���޸ģ�ˢ�������������ҳ���js������
            //��һ���Ȱ�װnuget����Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            //�ڶ�������services.AddControllersWithViews()�������.AddRazorRuntimeCompilation()
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #endregion



            #region ��������������
            services.AddDbContext<CosmetologynzsDBContext>(option => option.UseSqlServer("name=ConnectionStrings:SqlServerStr"));
            #endregion





            #region ���û������
            //���û������
            services.AddMemoryCache();
            #endregion
            #region ����Session����
            //����Session����
            services.AddSession();
            #endregion
            services.AddScoped<UserBLL>();//����ע������

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
            //����Session�����
            app.UseSession();
            //����Session�����
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Login}/{action=Loginview}/{id?}");
            //});


            app.UseEndpoints(endpoints =>
            {

                //·��

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
