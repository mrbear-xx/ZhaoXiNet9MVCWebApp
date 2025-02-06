using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using ZhaoXiNet9MVCWebApp.TestClass;
using ZhaoXiNet9MVCWebApp.TestClass.TestClassImpl;

namespace ZhaoXiNet9MVCWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //往服务容器注册举例
            builder.Services.AddTransient<IAccount, Account>();
            builder.Services.AddSingleton<IAccount, Account>();
            builder.Services.AddScoped<IAccount, Account>();

            ////使用autofac框架容器，在使用autofac容器时传入注册服务action，会被自动执行
            ////原理是在AutofacServiceProviderFactory注入这个ContainerBuilder会传递到WebApplicationBuilder，然后在其中会被执行
            ////此处演示注册一个接口下的所有实现类，并且使用autofac容器
            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory( containerBuilder =>
            //{
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    //程序集注册
            //    containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    //筛选命名空间为.IAccount
            //    .Where(w => w.Namespace == assembly.GetName().Name + ".IAccount")
            //    //暴露注册类型的接口
            //    .AsImplementedInterfaces()
            //    //生命周期模式为Scope
            //    .InstancePerLifetimeScope();
            //}));

            /*
             * Scrutor不是依赖注入框架，.Net内置DI的扩展包，弥补.Net内置DI服务注册方式，不会随版本更新出现异常，
             * 但是功能不如Autofac强大
             */
            builder.Services.Scan(scan => scan.FromAssemblyOf<Program>()
            .AddClasses(classes => classes.Where(w => w.Name.EndsWith("IAccount", StringComparison.OrdinalIgnoreCase)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithScopedLifetime()
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
