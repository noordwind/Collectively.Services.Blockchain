using System.Threading.Tasks;
using Collectively.Services.Blockchain.Services.Models;

namespace Collectively.Services.Blockchain.Services.BlokchainInfo
{
    public interface IBlokchainInfoService
    {
        Task<Address> GetAddressAsync(string id);
        Task<Transaction> GetTransactionAsync(string id);
    }
}