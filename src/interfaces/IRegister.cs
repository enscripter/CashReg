namespace CashReg.interfaces
{
    /// <summary>
    /// Public interface for a Register
    /// </summary>
    public interface IRegister<T>
    {
        /// <summary>
        /// Add something to this Register
        /// </summary>
        /// <param name="item">The item to be added</param>
        void Add(T item);
        /// <summary>
        /// The total of all items in the register
        /// </summary>
        /// <returns>The total value of all items in the Register</returns>
        decimal Total();
        /// <summary>
        /// Returns the number of unique items in this register
        /// </summary>
        /// <returns>The number of unique items in this register</returns>
        int UniqueItemCount();
        /// <summary>
        /// Print all the items and quantites and values
        /// </summary>
        void ListItems();
    }
}