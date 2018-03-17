namespace CashReg.interfaces
{
    /// <summary>
    /// A simple Converter interface for converting something into something else
    /// </summary>
    public interface IConverter<T, Q>
    {
        /// <summary>
        /// Convert method from a T to a Q
        /// </summary>
        /// <param name="input">The object to be converted</param>
        /// <returns>The converted object</returns>
        Q Convert(T input);
    }
}