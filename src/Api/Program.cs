using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Elmah.Io.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging((ctx, logging) =>
                {
                    logging.Services.Configure<ElmahIoProviderOptions>(ctx.Configuration.GetSection("ElmahIo"));
                    logging.AddElmahIo();
                    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Information);
                });
    }
}
