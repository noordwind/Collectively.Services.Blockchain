using System.Threading.Tasks;

namespace Collectively.Services.Blockchain.Services.BlockCypher
{
    public interface IBlockCypherService : IBlockchainService
    {
        Task<AddressDetails> GetAddressAsync(string id);
    }
}