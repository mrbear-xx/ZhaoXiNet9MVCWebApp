using Microsoft.Extensions.Options;

namespace ZhaoXiNet9MVCWebApp.OptionsTest
{
    public class OptionsTest4
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }

            public Behavior Behavior { get; set; }
        }

        public class Behavior
        {
            public bool IsRead { get; set; }
            public bool IsWrite { get; set; }
        }

        public static void Run()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("~/muti.json", true, true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<AppConfigerDemo>("DefaultApp", configuration.GetSection("Default"))
                .Configure<AppConfigerDemo>("CustomApp", configuration.GetSection("Custom"))
                .BuildServiceProvider();

            var options = serviceProvider.GetRequiredService<IOptionsMonitor<AppConfigerDemo>>();

            var changeDisposable = options.OnChange((appConfig,configName) =>
            {
                Console.Clear();
                Console.WriteLine($"configName:{configName}");
                Console.WriteLine($"Name:{appConfig?.Name}");
                Console.WriteLine($"StartDate:{appConfig?.StartDate}");
                Console.WriteLine($"EndDate:{appConfig?.EndDate}");
                Console.WriteLine($"Behavior:{appConfig?.Behavior.IsRead}");
                Console.WriteLine($"Behavior:{appConfig?.Behavior.IsWrite}");
            });

            Console.Read();
        }
    }
}
