using Prometheus.DotNetRuntime;
using Serilog;

namespace DF.WebApi
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddJsonFile(
                    path: $"appsettings.json.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT")}.json",
                    optional: true,
                    reloadOnChange: true)
                .Build();


            Log.Logger = new LoggerConfiguration()
                .CreateLogger();

            try
            {
                using (DotNetRuntimeStatsBuilder.Default().StartCollecting())
                    await CreateHostBuilder(args).Build().RunAsync();

                Log.Information("Stopped Cleanly");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .UseDefaultServiceProvider(
                (context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                });
    }
}
