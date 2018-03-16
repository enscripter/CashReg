using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A concrete Register implementation for ItemBase items
    /// </summary>
    public class ItemRegister : IRegister<ItemBase>
    {
        /// <summary>
        /// Add an ItemBase to this Register
        /// </summary>
        /// <param name="item">The ItemBase to be added</param>
        public void Add(ItemBase item)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Get the total of all ItemBase item in this register
        /// </summary>
        /// <returns>The total value of all ItemBase items minus any Discounts</returns>
        public float Total()
        {
            throw new System.NotImplementedException();
        }
    }
}