using Collectively.Services.Blockchain.Services.Mappers;
using Collectively.Services.Blockchain.Services.Models;

namespace Collectively.Services.Blockchain.Services.BlokchainInfo.Mappers
{
    public class BlockchainInfoTransactionMapper : ITransactionMapper<Transaction>
    {
        public Models.Transaction Map(Transaction source)
        => new Models.Transaction
        {
            DoubleSpend = source.DoubleSpend
        };
    }
}