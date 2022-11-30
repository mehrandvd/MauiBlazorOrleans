// See https://aka.ms/new-console-template for more information

using System.Net;
using MauiBlazorOrleans.Node.Grains.Implementations;
using MauiBlazorOrleans.Shared.Grains.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Clustering.AdoNet.Storage;

Console.WriteLine("Hello, World!");
//var myNumber = Console.ReadLine();

// Configure the host
using var host = new HostBuilder()
                 .UseOrleans(builder =>
                 {
                     //builder.UseDevelopmentClustering()
                     //       .Configure<ClusterOptions>(options =>
                     //       {
                     //           options.ClusterId = "dev";
                     //           options.ServiceId = "OrleansBasics";
                     //       });

                     builder.Configure<ClusterOptions>(options =>
                     {
                         options.ClusterId = "dev";
                         options.ServiceId = "OrleansBasics";
                     });

                     builder.UseAdoNetClustering(options =>
                     {
                         options.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=MauiBlazorOrleans;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
                         options.Invariant = "Microsoft.Data.SqlClient";
                     });
                 })
                 .Build();

// Start the host
await host.StartAsync();

// Get the grain factory
var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

// Get a reference to the HelloGrain grain with the key "friend"
var friend = grainFactory.GetGrain<IFulaFileGrain>("friend");

// Call the grain and print the result to the console
var result = await friend.GetFileInfoAsync("GoodMorning.jpg");

Console.WriteLine($"""

    {result}

    """);

Console.WriteLine("Orleans is running.\nPress Enter to terminate...");
Console.ReadLine();
Console.WriteLine("Orleans is stopping...");

await host.StopAsync();