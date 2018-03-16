using System;

namespace CashReg.objects
{
    /// <summary>
    /// An implementation of an Item that has a integer quantity
    /// </summary>
    public class QuantityItem : ItemBase
    {
        /// <summary>
        /// The quantity of this Item
        /// </summary>
        public int quantity;
        /// <summary>
        /// The total value of this Item
        /// </summary>
        /// <returns>The calculated value of the entire quantity of this Item</returns>
        public override float TotalValue()
        {
            throw new NotImplementedException();
        }
    }
}