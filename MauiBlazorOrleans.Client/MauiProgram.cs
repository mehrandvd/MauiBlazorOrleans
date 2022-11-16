using Microsoft.Extensions.Logging;
using MauiBlazorOrleans.Client.Data;
using MauiBlazorOrleans.Shared.Grains.Contracts;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Configuration;
using Orleans.Core;

namespace MauiBlazorOrleans.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if WINDOWS10_0_19041_0_OR_GREATER

        builder.Services.AddOrleansClient(clientBuilder =>
        {
            clientBuilder.UseLocalhostClustering();
            clientBuilder.UseAdoNetClustering(options =>
            {
                options.ConnectionString =
                    @"Data Source=.\sqlexpress;Initial Catalog=MauiBlazorOrleans;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
                options.Invariant = "Microsoft.Data.SqlClient";
            });

            clientBuilder.Configure<ClusterOptions>(options =>
                             {
                                 options.ClusterId = "dev";
                                 options.ServiceId = "OrleansBasics";
                             });
        });

#endif

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		var app = builder.Build();

        var c = app.Services.GetRequiredService<IClusterClient>();
        var g = c.GetGrain<IFulaFileGrain>("friends");
        var t = g.GetFileInfoAsync("GoodMorning.jpg");


        return app;
    }
}
