using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Primitives;

namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest4
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
            var configer = new ConfigurationBuilder()
                .AddJsonFile("~/appsettings.json", true, true)
                .Build();
            Read(configer.Get<AppConfigerDemo>());
            ChangeToken.OnChange(() => configer.GetReloadToken(), () =>
            {
                Read(configer.Get<AppConfigerDemo>());
            });
            Console.Read();
        }

        public static void Read(AppConfigerDemo options)
        {
            Console.Clear();
            Console.WriteLine($"Name:{options.Name}");
            Console.WriteLine($"StartDate:{options.StartDate}");
            Console.WriteLine($"EndDate:{options.EndDate}");
            Console.WriteLine($"EndDate:{options.Behavior.IsRead}");
            Console.WriteLine($"EndDate:{options.Behavior.IsWrite}");
        }
    }
}
