namespace Collectively.Services.Blockchain.Services
{
    public interface IDataMapper<TSource,TResult>
    {
         TResult Map(TSource source);
    }
}