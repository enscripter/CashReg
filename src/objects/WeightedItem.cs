using System;

namespace CashReg.objects
{
    /// <summary>
    /// An item that has a corresponding weight to calculate cost
    /// </summary>
    public class WeightedItem : ItemBase
    {
        /// <summary>
        /// The weight of the Item
        /// </summary>
        public float weight;
        /// <summary>
        /// Calcluate the total value of this Item
        /// </summary>
        /// <returns>The total value of this Item</returns>
        public override decimal TotalValue()
        {
            return (decimal)weight * value;
        }
        /// <summary>
        /// Friendly string
        /// </summary>
        /// <returns>A friendly string representation of this item</returns>
        public override string ToString()
        {
            return $"{weight} {name}@{value}";
        }
        /// <summary>
        /// Update this WeightedItem with additional weight from another WeightedItem,
        /// if item is not typeof WeightedItem this is a no-op
        /// </summary>
        /// <param name="item">The item whose </param>
        public override void Update(ItemBase item)
        {
            try {
                WeightedItem weightedItem = (WeightedItem) item;
                this.weight += weightedItem.weight;
            } catch (InvalidCastException) {
                return;
            }
        }
    }
}