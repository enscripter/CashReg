namespace CashReg.interfaces
{
    public interface IStore<T>
    {
        /// <summary>
        /// Add something to this Register
        /// </summary>
        /// <param name="item">The item to be added</param>
         void Add(T item);
    }
}