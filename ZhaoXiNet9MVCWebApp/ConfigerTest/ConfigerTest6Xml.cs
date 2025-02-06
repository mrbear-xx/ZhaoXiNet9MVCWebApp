using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest6Xml
    {
        /*
         IConfigurationBuilder对象利用注册在它上面的，所有IConfigurationSource对象提供
        的IConfigurationProvider对象，来读取原始配置数据，并创建出相应的IConfiguration
         */

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
                .AddXmlFile("~/AppConfigerTest.xml", true, true)
                .Build()
                .GetSection(nameof(AppConfigerDemo))
                .Get<AppConfigerDemo>();
            Console.WriteLine($"Name:{configer?.Name}");
            Console.WriteLine($"StartDate:{configer?.StartDate}");
            Console.WriteLine($"EndDate:{configer?.EndDate}");
            Console.WriteLine($"EndDate:{configer?.Behavior.IsRead}");
            Console.WriteLine($"EndDate:{configer?.Behavior.IsWrite}");
        }
    }
}
