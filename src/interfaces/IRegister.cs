namespace src.interfaces
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
        float Total();
    }
}