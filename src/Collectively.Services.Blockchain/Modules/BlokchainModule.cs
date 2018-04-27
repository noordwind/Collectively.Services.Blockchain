using Collectively.Services.Blockchain.Services.BlockCypher;
using Collectively.Services.Blockchain.Services.BlokchainInfo;

namespace Collectively.Services.Blockchain.Modules
{
    public class BlokchainModule : ModuleBase
    {
        public BlokchainModule(IBlockCypherService blockCypherService,
            IBlokchainInfoService blokchainInfoService) 
            : base(requireAuthentication: false)
        {
            Get("blockcypher/address/{id}", async args => await blockCypherService.GetAddressAsync(args.id));
            Get("blockchaininfo/address/{id}", async args => await blokchainInfoService.GetAddressAsync(args.id));
            Get("blockchaininfo/tx/{id}", async args => await blokchainInfoService.GetTransactionAsync(args.id));
        }
    }
}