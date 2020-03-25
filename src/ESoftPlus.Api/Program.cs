using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ESoftPlus.Common.Logging;
using ESoftPlus.Common.Metrics;
using ESoftPlus.Common.Mvc;
using ESoftPlus.Common.Vault;
using System;

namespace ESoftPlus.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();
    }
}
