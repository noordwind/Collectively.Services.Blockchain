using Collectively.Services.Blockchain.Services.Mappers;
using Collectively.Services.Blockchain.Services.Models;

namespace Collectively.Services.Blockchain.Services.BlokchainInfo.Mappers
{
    public class BlockchainInfoAddressMapper : IAddressMapper<Address>
    {
        public Models.Address Map(Address source)
        => new Models.Address
        {
            Hash160 = source.Hash160,
            Base58Check = source.Base58Check
        };
    }
}