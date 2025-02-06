using Microsoft.Extensions.Configuration.Json;

namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest3
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
            var options = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path= "~/appsettings.json" })
                .Build().Get<AppConfigerDemo>();
            Console.WriteLine($"Name:{options.Name}");
            Console.WriteLine($"StartDate:{options.StartDate}");
            Console.WriteLine($"EndDate:{options.EndDate}");
            Console.WriteLine($"EndDate:{options.Behavior.IsRead}");
            Console.WriteLine($"EndDate:{options.Behavior.IsWrite}");
        }
    }
}
