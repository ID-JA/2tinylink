using WebUI.Extensions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var app = builder.ConfigureServices();

        await app.ConfigurePipeline();
                         
        app.Run();
    }
}