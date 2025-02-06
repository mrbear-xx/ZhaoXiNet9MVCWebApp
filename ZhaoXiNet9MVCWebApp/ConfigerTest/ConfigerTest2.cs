using Microsoft.Extensions.Configuration.Memory;

namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest2
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
        }

        public static void Run()
        {
            var source = new Dictionary<string, string>
            {
                ["Name"] = "AppConfig",
                ["StartDate"] = "20250104",
                ["EndDate"] = "20250104"
            };
            var options = new ConfigurationBuilder()
                .AddInMemoryCollection(source).Build().Get<AppConfigerDemo>();
            Console.WriteLine($"Name:{options.Name}");
            Console.WriteLine($"StartDate:{options.StartDate}");
            Console.WriteLine($"EndDate:{options.EndDate}");
        }
    }
}
