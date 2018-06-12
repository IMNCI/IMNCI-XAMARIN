using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using IMNCI.Models;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace IMNCI
{
    public class OnlineDataStore
    {
        HttpClient client;
        IEnumerable<County> counties;
        public OnlineDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.ServerUrl}/");
        }

        public async Task<IEnumerable<County>> GetCountiesAsync(){
            if (CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/counties");
                counties = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<County>>(json));
            }

            return counties;
        }
    }
}
