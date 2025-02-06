namespace ZhaoXiNet9MVCWebApp.ConfigerTest
{
    public class ConfigerTest5CommandLine
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public Version Version { get; set; }
        }

        public static void Run(string[] args)
        {
            var mapping = new Dictionary<string, string>()
            {
                ["-n"] = "Name",
                ["-ver"] = "Version"
            };
            var configer = new ConfigurationBuilder()
                .AddCommandLine(args,mapping)
                .Build()
                .Get<AppConfigerDemo>();
            Console.WriteLine($"Name:{configer?.Name}");
            Console.WriteLine($"Name:{configer?.Version}");
        }
    }
}
