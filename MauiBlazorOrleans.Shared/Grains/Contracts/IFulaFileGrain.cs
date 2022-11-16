using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace MauiBlazorOrleans.Shared.Grains.Contracts
{
    public interface IFulaFileGrain : IGrainWithStringKey
    {
        Task<string> GetFileInfoAsync(string filename);
    }
}
