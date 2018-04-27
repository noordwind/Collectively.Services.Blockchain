using System;
using System.Net.Http;
using System.Threading.Tasks;
using Collectively.Services.Blockchain.Services.Mappers;
using Collectively.Services.Blockchain.Services.Models;
using Info.Blockchain.API.Client;
using Newtonsoft.Json;

namespace Collectively.Services.Blockchain.Services.BlokchainInfo
{
    public class BlokchainInfoService : IBlokchainInfoService
    {
        private readonly BlockchainHttpClient _client = new BlockchainHttpClient();
        private readonly ITransactionMapper<Transaction> _transactionMapper;
        private readonly IAddressMapper<Address> _addressMapper;

        public BlokchainInfoService(ITransactionMapper<Transaction> transactionMapper,
            IAddressMapper<Address> addressMapper)
        {
            _client = new BlockchainHttpClient();
            _transactionMapper = transactionMapper;
            _addressMapper = addressMapper;
        }

        public async Task<Models.Address> GetAddressAsync(string id)
        => await GetAndMapAsync<Address, Models.Address>($"pl/rawaddr/{id}", _addressMapper);

        public async Task<Models.Transaction> GetTransactionAsync(string id)
        => await GetAndMapAsync<Transaction,Models.Transaction>($"pl/rawtx/{id}", _transactionMapper);

        private async Task<TResult> GetAndMapAsync<TModel,TResult>(string endpoint, 
            IDataMapper<TModel, TResult> mapper)
        {
            var model = await _client.GetAsync<TModel>(endpoint);

            return mapper.Map(model);
        }
    }
}