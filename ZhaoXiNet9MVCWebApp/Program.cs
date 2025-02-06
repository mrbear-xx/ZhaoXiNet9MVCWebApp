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
            //����������ע�����
            builder.Services.AddTransient<IAccount, Account>();
            builder.Services.AddSingleton<IAccount, Account>();
            builder.Services.AddScoped<IAccount, Account>();

            ////ʹ��autofac�����������ʹ��autofac����ʱ����ע�����action���ᱻ�Զ�ִ��
            ////ԭ������AutofacServiceProviderFactoryע�����ContainerBuilder�ᴫ�ݵ�WebApplicationBuilder��Ȼ�������лᱻִ��
            ////�˴���ʾע��һ���ӿ��µ�����ʵ���࣬����ʹ��autofac����
            //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory( containerBuilder =>
            //{
            //    Assembly assembly = Assembly.GetExecutingAssembly();
            //    //����ע��
            //    containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    //ɸѡ�����ռ�Ϊ.IAccount
            //    .Where(w => w.Namespace == assembly.GetName().Name + ".IAccount")
            //    //��¶ע�����͵Ľӿ�
            //    .AsImplementedInterfaces()
            //    //��������ģʽΪScope
            //    .InstancePerLifetimeScope();
            //}));

            /*
             * Scrutor��������ע���ܣ�.Net����DI����չ�����ֲ�.Net����DI����ע�᷽ʽ��������汾���³����쳣��
             * ���ǹ��ܲ���Autofacǿ��
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
