using System.Collections.Generic;
using CashReg.objects;

namespace CashReg.interfaces
{
    /// <summary>
    /// An interface for something that can discount a IEnumerable of ItemBases
    /// </summary>
    public interface IDiscounter<T>
    {
        /// <summary>
        /// Return the discount of this applied to all ItemBases in the IEnumerable
        /// </summary>
        /// <param name="items">An iterable object of ItemBases</param>
        /// <returns>The total discount applied to all item</returns>
        float Discount(IEnumerable<T> items);
    }
}