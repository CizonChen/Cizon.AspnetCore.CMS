using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Cizon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Cizon.Domain.IRepositories;
using Cizon.EntityFrameworkCore.Repositories;
using Cizon.ApplicationService;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Cizon.CMS.MVC
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public  IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            // var sqlConnectionString = @"Server=127.0.0.1;port=3306;Database=cizoncms;Uid=root;Pwd=wsht2016";
            var sqlConnectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<CizonDbContext>(op=>op.UseMySql(sqlConnectionString));
            //依赖注入
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<IUserInfoAppService, UserInfoAppService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IRightRepository, RightRepository>();
            services.AddScoped<IRightAppService, RightAppService >();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleAppService, RoleAppService>();
            services.AddScoped<IRoleAssignmentRepository, RoleAssignmentRepository>();
            services.AddScoped<IRoleAssignmentAppService, RoleAssignmentAppService>();
            services.AddScoped<IRoleSetingRepository, RoleSetingRepository>();
            services.AddScoped<IRoleSetingAppService, RoleSetingAppService>();
            services.AddScoped<IDeptRepository, DeptRepository>();
            services.AddScoped<IDeptAppService, DeptAppService>(); 

            // Add framework services.
            services.AddMvc();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }

    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<CizonDbContext>
    {
        public CizonDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CizonDbContext>();
           
            var sqlConnectionString = @"Server=127.0.0.1;port=3306;Database=cizoncms;Uid=root;Pwd=wsht2016";
            builder.UseMySql(sqlConnectionString);
            return new CizonDbContext(builder.Options);
        }
    }
}
