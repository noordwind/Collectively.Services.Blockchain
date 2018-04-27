using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Collectively.Services.Blockchain.Services.BlockCypher
{
    public class BlockCypherService : IBlockCypherService
    {
        private readonly HttpClient _client;

        public BlockCypherService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://api.blockcypher.com")
            };           
        }

        public async Task<AddressDetails> GetAddressAsync(string id)
        {
            var response = await _client.GetAsync($"v1/btc/main/addrs/{id}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AddressDetails>(content);
        }
    }
}