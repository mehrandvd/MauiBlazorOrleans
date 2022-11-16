using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBlazorOrleans.Shared.Grains.Contracts;
using Orleans.Clustering.AdoNet.Storage;

namespace MauiBlazorOrleans.Client.Pages
{
    public partial class Counter
    {
        //IClusterClient _clusterClient;
        //public Counter(IClusterClient clusterClient)
        //{
        //    _clusterClient = clusterClient;
        //}
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }

        private async Task GetGrainAsyc()
        {
            //var client = new ClientBuilder(ServicesCollection)
            //    .UseAdoNetClustering(options =>
            //    {
            //        options.ConnectionString =
            //            @"Data Source=.\sqlexpress;Initial Catalog=MauiBlazorOrleans;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            //        options.Invariant = "Microsoft.Data.SqlClient";
            //    });
            //    //.Configure<ClusterOptions>(options =>
            //    //{
            //    //    options.ClusterId = "dev";
            //    //    options.ServiceId = "OrleansBasics";
            //    //})
            //    //.ConfigureLogging(logging => logging.AddConsole())

            //var x = _clusterClient.GetGrain<IFulaFileGrain>("friend");
            //var res = x.GetFileInfoAsync("GoodMorning.jpg");
            //Console.WriteLine("Client successfully connected to silo host \n");
        }
    }
}
