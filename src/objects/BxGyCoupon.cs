using System;
using System.Collections.Generic;
using System.Linq;
using CashReg.objects;

namespace CashReg.objects
{
    /// <summary>
    /// A Buy 'X' get 'Y' coupon where if you have 'X' items you get 'Y' for free,
    /// this type of Coupon only applies to QuantityItems
    /// </summary>
    public class BxGyCoupon : CouponBase
    {
        /// <summary>
        /// The Name of the item this Coupon applies to
        /// </summary>
        public string itemName;
        /// <summary>
        /// The quantity to have to get Y for free
        /// </summary>
        public int X;
        /// <summary>
        /// The quantity to get for free
        /// </summary>
        public int Y;
        /// <summary>
        /// Calculates the total discount of am IEnumerable of Items
        /// </summary>
        /// <param name="items">The items to generate the discount from</param>
        /// <returns>The calculated discount from the item</returns>
        public override decimal Discount(IEnumerable<ItemBase> items)
        {
            var existingItem = items.FirstOrDefault(i => i.name == itemName);
            if (existingItem == null)
                return 0;
            QuantityItem applicableItem;
            if (existingItem.GetType() == typeof(QuantityItem))
                applicableItem = (QuantityItem) existingItem;
            else
                return 0;
            if (applicableItem == null)
                return 0m;
            var fullDiscounts = applicableItem.quantity / (X + Y);
            if (applicableItem.quantity == fullDiscounts * (X + Y))
                return fullDiscounts * Y * applicableItem.value;
            else if (applicableItem.quantity > X && applicableItem.quantity < fullDiscounts * (X + Y) + X + Y)
                return (fullDiscounts * Y * applicableItem.value) + (applicableItem.quantity % (X + Y) - X);
            else
                return 0;
        }
    }
}