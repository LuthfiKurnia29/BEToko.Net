using api;

#pragma warning disable CA1050 // Declare types in namespaces
public class Program
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder => {
                builder.UseStartup<Startup>();
            });
    }
}