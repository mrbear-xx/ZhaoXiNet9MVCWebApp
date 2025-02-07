using Microsoft.Extensions.Options;

namespace ZhaoXiNet9MVCWebApp.OptionsTest
{
    public class OptionsTest5
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        public static void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<AppConfigerDemo>(config =>
                {
                    config.Name = "DefaultApp";
                    config.StartDate = "2025/01/14";
                    config.EndDate = "2025/01/14";
                })
                .BuildServiceProvider();

            var options = serviceProvider.GetRequiredService<IOptions<AppConfigerDemo>>();

            var customApp = options.Value;

            Console.WriteLine($"Name:{customApp?.Name}");
            Console.WriteLine($"StartDate:{customApp?.StartDate}");
            Console.WriteLine($"EndDate:{customApp?.EndDate}");
        }
    }
}
