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
        public override decimal TotalValue()
        {
            return value * (decimal) quantity;
        }
        /// <summary>
        /// Update this QuantityItem with additional quantities from another QuantityItem,
        /// if item is not typeof QuantityItem this is a no-op
        /// </summary>
        /// <param name="item">The Item to update this Item with</param>
        public override void Update(ItemBase item)
        {
            try {
                QuantityItem quantityItem = (QuantityItem) item;
                this.quantity += quantityItem.quantity;
            } catch (InvalidCastException) {
                return;
            }
        }
    }
}