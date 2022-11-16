using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBlazorOrleans.Shared.Grains.Contracts;
using Orleans;

namespace MauiBlazorOrleans.Node.Grains.Implementations
{
    public class FulaFileGrain : Grain, IFulaFileGrain
    {
        public Task<string> GetFileInfoAsync(string filename)
        {
            Console.WriteLine("Got the grain from here...");
            return Task.FromResult($"Information for the file {IdentityString}/{filename}");
        }
    }
}
