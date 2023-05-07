namespace ArithmeticStrategyOperation.Interfaces
{
    public interface IWriteOutputStrategy
    {
        Task Write<TResult>(TResult result);
    }
}
