namespace ArithmeticStrategyOperation.Interfaces
{
    /// <summary>
    /// Write output Strategy. Output could be anything like Console, File or Message Queue. 
    /// </summary>
    public interface IWriteOutputStrategy
    {
        /// <summary>
        /// Write output to different source like Console, File, Message Queue or Email
        /// </summary>
        /// <typeparam name="TResult">Type of output</typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        Task Write<TResult>(TResult result);
    }
}
