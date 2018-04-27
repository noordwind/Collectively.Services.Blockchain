using Collectively.Services.Blockchain.Services.Models;

namespace Collectively.Services.Blockchain.Services.Mappers
{
    public interface ITransactionMapper<TSource> : IDataMapper<TSource,Transaction>
    {
    }
}