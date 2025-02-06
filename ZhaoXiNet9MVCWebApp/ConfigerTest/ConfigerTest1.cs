using Microsoft.Extensions.Configuration.Memory;

namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest1
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }

            public AppConfigerDemo(IConfiguration config)
            {
                Name = config["Name"];
                StartDate = config["StartDate"];
                EndDate = config["EndDate"];
            }
        }

        public static void Run()
        {
            var source = new Dictionary<string, string>
            {
                ["Name"] = "AppConfig",
                ["StartDate"] = "20250104",
                ["EndDate"] = "20250104"
            };
            var configer = new ConfigurationBuilder()
                .Add(new MemoryConfigurationSource { InitialData = source })
                .Build();
            var options = new AppConfigerDemo(configer);
            Console.WriteLine($"Name:{options.Name}");
            Console.WriteLine($"StartDate:{options.StartDate}");
            Console.WriteLine($"EndDate:{options.EndDate}");
        }
    }
}
