using IoC.Pay;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Tests.Pay.TDD.Config
{
    public class StartInjection
    {
        public StartInjection()
        {
            BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; } = StartConfiguration.Configuration;

        void BuildServiceProvider()
        {
            var _services = new ServiceCollection();
            _services.RegisterDbContextInMemory();
            _services.RegisterServices(Configuration, true);
            _services.AddSingleton(x => this.Configuration);

            _services.RegisterServices(Configuration, true);

            ServiceProvider = _services.BuildServiceProvider();
        }
    }

    public static class StartConfiguration
    {
        public static IConfiguration Configuration { get; private set; }

        static StartConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
