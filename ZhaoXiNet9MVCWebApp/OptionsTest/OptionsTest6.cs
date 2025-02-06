using Microsoft.Extensions.Options;

namespace ZhaoXiNet9MVCWebApp.OptionsTest
{
    public class OptionsTest6
    {
        public class AppConfigerDemo
        {
            public string Name { get; set; }
            public string Version { get; set; }
        }

        public static void Run(string[] args)
        {
            var mapping = new Dictionary<string, string>()
            {
                ["-n"] = "Name",
                ["-ver"] = "Version"
            };
            var configer = new ConfigurationBuilder()
                .AddCommandLine(args, mapping)
                .Build();

            var services = new ServiceCollection();
            services.AddOptions<AppConfigerDemo>()
                .Configure(options =>
                {
                    options.Name = configer["Name"] ?? "";
                    options.Version = configer["Version"] ?? "";
                }).Validate(demo => demo.Version.StartsWith("Alpha"), "Version 参数无效")
                .Validate(demo => demo.Name.EndsWith("App"), "Name 参数无效");

            try
            {
                var options = services.BuildServiceProvider()
                    .GetRequiredService<IOptions<AppConfigerDemo>>().Value;
                Console.WriteLine(options.Name);
                Console.WriteLine(options.Version);
            }catch(OptionsValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
