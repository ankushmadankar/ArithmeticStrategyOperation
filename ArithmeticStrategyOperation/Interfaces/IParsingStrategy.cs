namespace ArithmeticStrategyOperation.Interfaces
{
    /// <summary>
    /// Define the parsing strategy how values will be operated.
    /// </summary>
    public interface IParsingStrategy
    {
        /// <summary>
        /// Parse numbers with required strategy e.g. Sum, Multiplication
        /// </summary>
        /// <returns></returns>
        Task<double> ParseNumbers();
    }
}
