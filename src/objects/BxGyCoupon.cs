using System.Collections.Generic;
using System.Linq;
using CashReg.objects;

namespace CashReg.objects
{
    /// <summary>
    /// A Buy 'X' get 'Y' coupon where if you have 'X' items you get 'Y' for free,
    /// this type of Coupon only applies to QuantityItems
    /// </summary>
    public class BxGyCoupon : CouponBase<QuantityItem>
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
        /// <returns>The calculated discoun from the item</returns>
        public override decimal Discount(IEnumerable<QuantityItem> items)
        {
            var applicableItem = items.FirstOrDefault(i => i.name == itemName);
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