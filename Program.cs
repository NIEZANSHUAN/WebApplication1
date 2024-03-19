using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;

namespace WebApplication1
{
    public class Program
    {
        public static void SS()
        { 
            Admin admin = new Admin();
            admin.Id = 1;
            int id2= 22;

        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            decimal a = 2.1m;


            int[] s1 = new int[3];
            int[] s2 = { 2, 3 };
            int[] s4 = new int[] { 1, 2 };


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
