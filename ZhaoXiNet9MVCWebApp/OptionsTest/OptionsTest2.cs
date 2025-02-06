using Microsoft.Extensions.Options;

namespace ZhaoXiNet9MVCWebApp.OptionsTest
{
    public class OptionsTest2
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        public static void Run()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("~/muti.json", true, true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<AppConfigerDemo>("DefaultApp",configuration.GetSection("Default"))
                .Configure<AppConfigerDemo>("CustomApp",configuration.GetSection("Custom"))
                .BuildServiceProvider();

            var options = serviceProvider.GetRequiredService<IOptionsSnapshot<AppConfigerDemo>>();

            var defaultApp = options.Get("DefaultApp");
            var customApp = options.Get("CustomApp");

            Console.WriteLine($"Name:{defaultApp?.Name}");
            Console.WriteLine($"StartDate:{defaultApp?.StartDate}");
            Console.WriteLine($"EndDate:{defaultApp?.EndDate}");
            Console.WriteLine($"Name:{customApp?.Name}");
            Console.WriteLine($"StartDate:{customApp?.StartDate}");
            Console.WriteLine($"EndDate:{customApp?.EndDate}");
        }
    }
}
